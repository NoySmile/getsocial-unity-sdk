﻿#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GetSocialSdk.Core
{
    internal static class ThriftConversions
    {
        public static Dictionary<string, string> IdentitiesToDictionary(this List<THIdentity> identities)
        {
            identities = identities ?? new List<THIdentity>();
            return identities.ToDictionary(identity => identity.Provider, identity => identity.ProviderId);
        }

        public static ConflictUser ToConflictUser(this THPrivateUser conflictUser)
        {
            return new ConflictUser
            {
                PublicProperties = conflictUser.PublicProperties,
                Id = conflictUser.Id,
                Identities = IdentitiesToDictionary(conflictUser.Identities),
                Verified = false,
                AvatarUrl = conflictUser.AvatarUrl,
                DisplayName = conflictUser.DisplayName,
                BanInfo = ConvertBanInfo(conflictUser.InternalPrivateProperties),
                PrivateProperties = conflictUser.PrivateProperties
            };
        }

        public static CurrentUser ToCurrentUser(this THPrivateUser currentUser)
        {
            return new CurrentUser
            {
                PublicProperties = currentUser.PublicProperties,
                Id = currentUser.Id,
                Identities = IdentitiesToDictionary(currentUser.Identities),
                Verified = false,
                AvatarUrl = currentUser.AvatarUrl,
                DisplayName = currentUser.DisplayName,
                BanInfo = ConvertBanInfo(currentUser.InternalPrivateProperties),
                PrivateProperties = currentUser.PrivateProperties
            };
        }

        private static BanInfo ConvertBanInfo(Dictionary<string, string> privateProperties)
        {
            if (privateProperties == null)
            {
                return null;
            }

            if (!privateProperties.ContainsKey("expiry"))
            {
                return null;
            }

            var expiry = long.Parse(privateProperties["ban_expiry"]);
            var reason = privateProperties.ContainsKey("ban_reason") ? privateProperties["ban_reason"] : null;
            return new BanInfo
            {
                Expiration = expiry,
                Reason = reason
            };
        }

        public static THPrivateUser ToRPC(this UserUpdate userUpdate)
        {
            // todo add media
            return new THPrivateUser
            {
                AvatarUrl = userUpdate.AvatarUrl,
                DisplayName = userUpdate.DisplayName,
                PublicProperties = userUpdate._publicProperties,
                PrivateProperties = userUpdate._privateProperties,
            };
        }

        public static SuggestedFriend ToSuggestedFriend(this THSuggestedFriend suggestedFriend)
        {
            var user = suggestedFriend.User;
            return new SuggestedFriend {
                PublicProperties = user.PublicProperties,
                Id = user.Id,
                Identities = IdentitiesToDictionary(user.Identities),
                Verified = false,
                AvatarUrl = user.AvatarUrl,
                DisplayName = user.DisplayName,
                MutualFriendsCount = suggestedFriend.MutualFriends
            };
        }

        public static PagingResult<T> ToPagingResult<T>(List<T> entries, int offset, int limit)
        {
            var next = entries.Count < limit ? "" : (offset + limit).ToString();
            return new PagingResult<T>
            {
                Entries = entries,
                NextCursor = next
            };
        }

        public static ReferralUser FromRPCModel(this THReferralUser thReferralUser)
        {
            var user = thReferralUser.User;
            return new ReferralUser
            {
                PublicProperties = user.PublicProperties,
                Id = user.Id,
                Identities = IdentitiesToDictionary(user.Identities),
                Verified = false,
                AvatarUrl = user.AvatarUrl,
                DisplayName = user.DisplayName,
                EventData = thReferralUser.CustomData ?? new Dictionary<string, string>(), 
                Event = thReferralUser.Event,
                EventDate = long.Parse(thReferralUser.EventDate),
            };
        }

        public static THIdentity ToRpcModel(this Identity identity)
        {
            return new THIdentity
            {
                Provider = identity.ProviderId,
                ProviderId = identity.ProviderUserId,
                AccessToken = identity.AccessToken
            };
        }

        public static InviteChannel FromRpcModel(this THInviteProvider provider, string language)
        {
            return new InviteChannel{
                Id = provider.ProviderId,
                IconImageUrl = provider.IconUrl,
                DisplayOrder = provider.DisplayOrder,
                Name = provider.Name.ContainsKey(language) ? provider.Name[language] : provider.Name[LanguageCodes.DefaultLanguage]
            };
        }

        public static THAnalyticsBaseEvent ToRpcModel(this AnalyticsEvent e)
        {
            return new THAnalyticsBaseEvent
            {
                Id = e.Id,
                Name = e.Name,
                CustomProperties = e.Properties,
                DeviceTimeType = THDeviceTimeType.SERVER_TIME,
                DeviceTime = e.CreatedAt.ToUnixTimestamp(),
                RetryCount = 0
            };
        }

        public static THDeviceOs ToRpcModel(this OperatingSystemFamily operatingSystemFamily)
        {
#if UNITY_EDITOR
            return THDeviceOs.UNITY_EDITOR;
#else
            return new Dictionary<OperatingSystemFamily, THDeviceOs>
            {
                {OperatingSystemFamily.MacOSX, THDeviceOs.DESKTOP_MAC},
                {OperatingSystemFamily.Windows, THDeviceOs.DESKTOP_WINDOWS},
                {OperatingSystemFamily.Linux, THDeviceOs.DESKTOP_LINUX},
                {OperatingSystemFamily.Other, THDeviceOs.OTHER},
            }[operatingSystemFamily];
#endif
        }

        public static GetSocialAction FromRpcModel(this THAction thAction)
        {
            return GetSocialAction.Create(thAction.Type, thAction.Data ?? new Dictionary<string, string>());
        }

        public static THAction ToRpcModel(this GetSocialAction thAction)
        {
            return thAction == null ? null : new THAction
            {
                Type = thAction.Type,
                Data = thAction.Data
            };
        }

        public static NotificationCustomization FromRpcModel(
            this THNotificationTemplateMedia thNotificationTemplateMedia)
        {
            if (thNotificationTemplateMedia == null)
            {
                return null;
            }

            var backgroundImageConfiguration = thNotificationTemplateMedia.BackgroundImage;
            var titleColor = thNotificationTemplateMedia.TitleColor;
            var textColor = thNotificationTemplateMedia.TextColor;
            return NotificationCustomization.WithBackgroundImageConfiguration(backgroundImageConfiguration)
                .WithTextColor(textColor)
                .WithTitleColor(titleColor);
        }

        public static THBadge ToRpcModel(this Badge badge)
        {
            if (badge == null)
            {
                return null;
            }
            if (badge.Value == int.MinValue)
            {
                return new THBadge { Increase = badge.Increase };
            }
            return new THBadge { Value = badge.Value };
        }

        public static THActionButton ToRpcModel(this NotificationButton button)
        {
            return new THActionButton
            {
                Title = button.Title,
                ActionId = button.ActionId
            };
        }

        public static NotificationButton FromRpcModel(this THActionButton button)
        {
            return NotificationButton.Create(button.Title, button.ActionId);
        }

        #region SDK7

        public static GetUsersRequest ToRpc(this PagingQuery<UsersQuery> query)
        {
            var request = query.Query.ToRpc();
            request.Pagination = query.ToPagination();
            return request;
        }

        public static GetActivitiesV2Request ToRpc(this PagingQuery<ActivitiesQuery> query)
        {
            var request = query.Query.ToRpc();
            request.Pagination = query.ToPagination();
            return request;
        }
        
        public static GetAnnouncementsRequest ToRpc(this AnnouncementsQuery query)
        {
            return new GetAnnouncementsRequest
            {
                Target = query.Ids.ToRpc()
            };
        }
        public static GetReactionsRequest ToRpc(this PagingQuery<ReactionsQuery> query)
        {
            var request = query.Query.ToRpc();
            request.Pagination = query.ToPagination();
            return request;
        }

        public static GetReactionsRequest ToRpc(this ReactionsQuery query)
        {
            return new GetReactionsRequest
            {
                Reaction = query.Reaction, Target = query.Ids.ToRpc()
            };
        }

        public static FindTagsRequest ToRpc(this TagsQuery query)
        {
            return new FindTagsRequest
            {
                SearchTerm = query.Query,
                Target = query.Target?.Ids.ToRpc()
            };
        }

        public static GetActivitiesV2Request ToRpc(this ActivitiesQuery query)
        {
            return new GetActivitiesV2Request
            {
                Target = query.Ids.ToRpc()
            };
        }

        public static AFButton ToRpc(this ActivityButton button)
        {
            return new AFButton
            {
                Action = button.Action.ToRpcModel(),
                ButtonTitle = button.Title
            };
        }

        public static CreateActivityRequest ToRpc(this ActivityContent content, string lang, PostActivityTarget target)
        {
            return new CreateActivityRequest
            {
                Target = target.Ids.ToRpc(),
                Properties = content.Properties,
                Content = new Dictionary<string, AFContent>
                {
                    {lang, new AFContent
                    {
                        Text = content.Text,
                        Button = content.Button?.ToRpc(),
                        Attachments = content.Attachments.ConvertAll(it => it.ToRpc())
                    }}
                }
            };
        }

        public static UpdateActivityRequest ToUpdateRpc(this ActivityContent content, string lang, string activityId)
        {
            return new UpdateActivityRequest
            {
                ActivityId = activityId,
                Properties = content.Properties,
                Content = new Dictionary<string, AFContent>
                {
                    {lang, new AFContent
                    {
                        Text = content.Text,
                        Button = content.Button?.ToRpc(),
                        Attachments = content.Attachments.ConvertAll(it => it.ToRpc())
                    }}
                }
            };
        }
        public static MediaAttachment FromRpc(this AFAttachment attachment)
        {
            return new MediaAttachment
            {
                ImageUrl = attachment.ImageUrl,
                VideoUrl = attachment.VideoUrl
            };
        }
        public static AFAttachment ToRpc(this MediaAttachment attachment)
        {
            return new AFAttachment
            {
                ImageUrl = attachment.ImageUrl,
                VideoUrl = attachment.VideoUrl
            };
        }
        
        public static GetFriendsRequest ToRpc(this PagingQuery<FriendsQuery> query)
        {
            var request = query.Query.ToRpc();
            request.Pagination = query.ToPagination();
            return request;
        }

        public static GetFriendsRequest ToRpc(this FriendsQuery query)
        {
            return new GetFriendsRequest
            {
                UserId = query.UserId.ToRpc()
            };
        }

        public static SGEntity ToRpc(this CommunitiesIds ids)
        {
            if (ids == null || ids.Type == null)
            {
                return null;
            }
            return new SGEntity
            {
                EntityType = (int) ids.Type, Id = ids.Ids[0]
            };
        }

        public static SuggestedFriend FromRPCModel(this THSuggestedFriend friend)
        {
            var user = friend.User;
            return new SuggestedFriend
            {
                PublicProperties = user.PublicProperties,
                Id = user.Id,
                Identities = IdentitiesToDictionary(user.Identities),
                Verified = false,
                AvatarUrl = user.AvatarUrl,
                DisplayName = user.DisplayName, 
                MutualFriendsCount = friend.MutualFriends
            };
        }
        public static PagingResult<SuggestedFriend> FromRPCModel(this GetSuggestedFriendsResponse response)
        {
            return FromRPCModel(response.Users, response.NextCursor, FromRPCModel);
        }
        
        public static PagingResult<User> FromRPCModel(this GetFriendsResponse response)
        {
            return FromRPCModel(response.Users, response.NextCursor, FromRPCModel);
        }

        public static PagingResult<User> FromRPCModel(this GetUsersResponse response)
        {
            return FromRPCModel(response.Users, response.NextCursor, FromRPCModel);
        }
        
        public static PagingResult<Activity> FromRPCModel(this GetActivitiesV2Response response)
        {
            var users = response.Authors;
            var sources = response.EntityDetails;
            return FromRPCModel(response.Data, response.NextCursor, af =>
            {
                var id = af.Author.PublicUser?.Id;
                var user = id != null && users.ContainsKey(id) ? users[id] : null;
                var source = FindSource(sources, af.Source);
                return FromRPCModel(af, user, source);
            });
        }

        private static AFEntityReference FindSource(List<AFEntityReference> list, AFEntityReference source)
        {
            if (source == null || source.Id == null)
            {
                return null;
            }

            foreach (var reference in list) 
            {
                if (source.Id.Id.Equals(reference.Id.Id) && source.Id.EntityType == reference.Id.EntityType)
                {
                    return reference;
                }
            }

            return source;
        }

        public static Activity FromRPCModel(this AFActivity activity, THPublicUser user = null, AFEntityReference source = null)
        {
            var content = activity.Content.FirstValue(new AFContent());
            return new Activity
            {
                Id = activity.Id,
                Type = activity.ContentType, 
                Announcement = activity.IsAnnouncement, 
                Button = content.Button.FromRPCModel(), 
                Author = activity.Author.FromRPCModel(user),
                Properties = activity.Properties ?? new Dictionary<string, string>(),
                CreatedAt = activity.CreatedAt,
                ViewCount = activity.Reactions.ViewCount,
                CommentsCount = activity.Reactions.CommentCount,
                MediaAttachments = (content.Attachments ?? new List<AFAttachment>()).ConvertAll(FromRpc),
                Text = content.Text,
                ReactionsCount = activity.Reactions.ReactionCount,
                MyReactionsList = activity.Reactions.MyReactions ?? new List<string>(), 
                Mentions = activity.Mentions.FirstValue(new List<AFMention>()).ConvertAll(FromRPCModel), 
                Source = (source ?? activity.Source).FromRPCModel(),
                Status = activity.Status ?? ""
            };
        }

        public static CommunitiesEntity FromRPCModel(this AFEntityReference source)
        {
            return new CommunitiesEntity
            {
                Type = (CommunitiesEntityType) source.Id.EntityType, 
                Id = source.Id.Id,
                Title = source.Title.FirstValue(),
                AvatarUrl = source.AvatarUrl,
                FollowersCount = source.FollowersCount,
                IsFollower = source.IsFollower,
                AvailableActions = ConvertAllowableActions(source.AllowedActions)
            };
        }

        public static T FirstValue<K, T>(this Dictionary<K, T> dictionary, T def)
        {
            return dictionary == null || dictionary.Count == 0 ? def : dictionary.First().Value;
        }

        public static string FirstValue<K>(this Dictionary<K, string> dictionary)
        {
            return dictionary.FirstValue("");
        }

        public static Mention FromRPCModel(this AFMention mention)
        {
            return new Mention {UserId = mention.UserId, StartIndex = mention.StartIdx, EndIndex = mention.EndIdx, Type = mention.MentionType == 0 ? Mention.MentionType.App : Mention.MentionType.User};
        }

        public static ActivityButton FromRPCModel(this AFButton button)
        {
            if (button == null)
            {
                return null;
            }
            return ActivityButton.Create(button.ButtonTitle, button.Action.FromRpcModel());
        }

        public static User FromRPCModel(this THPublicUser user)
        {
            return new User
            {
                PublicProperties = user.PublicProperties,
                Id = user.Id,
                Identities = IdentitiesToDictionary(user.Identities),
                Verified = false,
                AvatarUrl = user.AvatarUrl,
                DisplayName = user.DisplayName
            };
        }
        
        public static User FromRPCModel(this THCreator creator, THPublicUser user = null)
        {
            if (creator.IsApp)
            {
                return new User
                {
                    Id = "app",
                    AvatarUrl = GetSocialStateController.Info.IconUrl,
                    DisplayName = GetSocialStateController.Info.Name,
                    Identities = new Dictionary<string, string>(),
                    Verified = true,
                    PublicProperties = new Dictionary<string, string>()
                };
            }

            if (user == null)
            {
                user = creator.PublicUser;
            }

            if (user == null)
            {
                return null;
            }
            return new User
            {
                PublicProperties = user.PublicProperties,
                Id = user.Id,
                Identities = IdentitiesToDictionary(user.Identities),
                Verified = creator.IsVerified,
                AvatarUrl = user.AvatarUrl,
                DisplayName = user.DisplayName
            };
        }

        public static GetUsersRequest ToRpc(this UsersQuery query)
        {
            return new GetUsersRequest
            {
                SearchTerm = query.Query,
                FollowedByUserId = query.FollowedBy.ToRpc()
            };
        }

        public static string ToRpc(this UserId userId)
        {
            return userId?.AsString();
        }

        public static CommunitiesAction[] CommunitiesActionFromRPC(int rawValue)
        {
            switch (rawValue)
            {
                case 0:
                    return new CommunitiesAction[] { CommunitiesAction.Post };
                default:
                    return new CommunitiesAction[] { CommunitiesAction.Comment, CommunitiesAction.React };
            }
        }

        public static CommunitiesSettings FromRPC(this SGSettings rpcSettings)
        {
            return new CommunitiesSettings
            {
                Properties = rpcSettings.Properties,
                AllowedActions = ConvertAllowableActions(rpcSettings.AllowedActions)
            };
        }

        public static Dictionary<CommunitiesAction, bool> ConvertAllowableActions(this Dictionary<int, bool> actions)
        {
            var allowedActions = new Dictionary<CommunitiesAction, bool>();
            if (actions != null) {
                foreach (var action in actions)
                {
                    var convertedActions = CommunitiesActionFromRPC(action.Key);
                    for (int i = 0; i<convertedActions.Length; i++)
                    {
                        allowedActions[convertedActions[i]] = action.Value;
                    }
                }
            }

            return allowedActions;
        }

        public static GetTopicsRequest ToRPC(this TopicsQuery query)
        {
            var request = new GetTopicsRequest();
            request.FollowedByUserId = query.FollowerId.ToRpc();
            request.SearchTerm = query.SearchTerm;
            return request;
        }

        public static GetTopicsRequest ToRPC(this PagingQuery<TopicsQuery> pagingQuery)
        {
            var request = pagingQuery.Query.ToRPC();
            request.Pagination = CreatePagination(pagingQuery);
            return request;
        }
        
        public static GetNotificationsRequest ToRPC(this PagingQuery<NotificationsQuery> pagingQuery)
        {
            var request = pagingQuery.Query.ToRPC();
            request.Pagination = CreatePagination(pagingQuery);
            return request;
        }

        public static GetNotificationsRequest ToRPC(this NotificationsQuery query)
        {
            return new GetNotificationsRequest
            {
                Statuses = query.Statuses,
                Actions = query.Actions,
                Types = query.Types
            };
        }

        public static GetGroupMembersRequest ToRPC(this PagingQuery<GroupMembersQuery> pagingQuery)
        {
            var request = pagingQuery.Query.ToRPC();
            request.Pagination = CreatePagination(pagingQuery);
            return request;
        }

        public static GetGroupMembersRequest ToRPC(this GroupMembersQuery query)
        {
            var request = new GetGroupMembersRequest();
            request.GroupId = query.GroupId;
            request.Info = new SGMembershipInfo();
            request.Info.Status = (int)query.Status;
            request.Info.Role = (int)query.Role;
            return request;
        }

        public static GetGroupsRequest ToRPC(this PagingQuery<GroupsQuery> pagingQuery)
        {
            var request = pagingQuery.Query.ToRPC();
            request.Pagination = CreatePagination(pagingQuery);
            return request;
        }

        public static GetGroupsRequest ToRPC(this GroupsQuery query)
        {
            var request = new GetGroupsRequest();
            request.FollowedByUserId = query.FollowerId.ToRpc();
            request.MemberUserId = query.MemberId.ToRpc();
            request.SearchTerm = query.SearchTerm;
            return request;
        }

        public static UpdateMembersRequest ToRPC(this UpdateGroupMembersQuery query)
        {
            var request = new UpdateMembersRequest();
            request.GroupId = query.GroupId;
            request.Info = new SGMembershipInfo();
            request.Info.Status = (int)query.Status;
            request.UserIds = query.UserIdList.AsString();
            return request;
        }

        public static RemoveMembersRequest ToRPC(this RemoveGroupMembersQuery query)
        {
            var request = new RemoveMembersRequest();
            request.GroupId = query.GroupId;
            request.UserIds = query.UserIdList.AsString();
            return request;
        }

        public static FollowEntitiesRequest ToRPC(this FollowQuery query)
        {
            var request = new FollowEntitiesRequest();
            request.EntityIds = new Thrift.Collections.THashSet<string>();
            request.EntityIds.AddAll(query.Ids.Ids);
            request.EntityType = (int)query.Ids.Type;
            return request;
        }

        public static UnfollowEntitiesRequest ToUnfollowRPC(this FollowQuery query)
        {
            var request = new UnfollowEntitiesRequest();
            request.EntityIds = new Thrift.Collections.THashSet<string>();
            request.EntityIds.AddAll(query.Ids.Ids);
            request.EntityType = (int)query.Ids.Type;
            return request;
        }


        public static IsFollowingRequest ToIsFollowingRPC(this FollowQuery query)
        {
            var request = new IsFollowingRequest();
            request.EntityIds = new Thrift.Collections.THashSet<string>();
            request.EntityIds.AddAll(query.Ids.Ids);
            request.EntityType = (int)query.Ids.Type;
            return request;
        }

        public static GetEntityFollowersRequest ToRPC(this PagingQuery<FollowersQuery> pagingQuery)
        {
            var request = pagingQuery.Query.ToRPC();
            request.Pagination = CreatePagination(pagingQuery);
            return request;
        }

        public static GetEntityFollowersRequest ToRPC(this FollowersQuery query)
        {
            var request = new GetEntityFollowersRequest();
            request.Id = new SGEntity();
            request.Id.Id = query.Ids.Ids.First() ;
            request.Id.EntityType = (int)query.Ids.Type;
            return request;
        }

        public static Pagination CreatePagination<T>(PagingQuery<T> pagingQuery)

        {
            var pagination = new Pagination();
            pagination.Limit = pagingQuery.Limit;
            pagination.NextCursor = pagingQuery.NextCursor;
            return pagination;
        }

        public static Topic FromRPCModel(this SGTopic rpcTopic)
        {
            var topic = new Topic();
            topic.Id = rpcTopic.Id;
            topic.AvatarUrl = rpcTopic.AvatarUrl;
            topic.CreatedAt = rpcTopic.CreatedAt;
            topic.Description =  new LocalizableText(rpcTopic.TopicDescription).LocalizedValue();
            topic.FollowersCount = rpcTopic.FollowersCount;
            topic.IsFollowedByMe = rpcTopic.IsFollower;
            topic.Title = new LocalizableText(rpcTopic.Title).LocalizedValue();
            topic.Settings = rpcTopic.Settings.FromRPC();
            topic.UpdatedAt = rpcTopic.UpdatedAt;
            return topic;
        }

        public static CreateGroupRequest ToRPC(this GroupContent content)
        {
            var request = new CreateGroupRequest();
            request.Id = content.Id;
            // FIXME: use proper locale
            request.Title = new Dictionary<string, string> { { "en", content.Title } };
            request.GroupDescription = new Dictionary<string, string> { { "en", content.Description } };
            request.AvatarUrl = content.AvatarUrl;
            request.IsDiscoverable = content.IsDiscoverable;
            request.IsPrivate = content.IsPrivate;
            var permissions = new Dictionary<int, int>();
            foreach (var entry in content.Permissions)
            {
                permissions[(int)entry.Key] = (int)entry.Value;
            }
            request.Permissions = permissions;
            request.Properties = content.Properties;
            return request;
        }

        public static UpdateGroupRequest ToUpdateRPC(this GroupContent content)
        {
            var request = new UpdateGroupRequest();
            request.Id = content.Id;
            // FIXME: use proper locale
            request.Title = new Dictionary<string, string> { { "en", content.Title } };
            request.GroupDescription = new Dictionary<string, string> { { "en", content.Description } };
            request.AvatarUrl = content.AvatarUrl;
            request.IsDiscoverable = content.IsDiscoverable;
            request.IsPrivate = content.IsPrivate;
            var permissions = new Dictionary<int, int>();
            foreach (var entry in content.Permissions)
            {
                permissions[(int)entry.Key] = (int)entry.Value;
            }
            request.Permissions = permissions;
            request.Properties = content.Properties;
            return request;
        }

        public static Group FromRPCModel(this SGGroup rpcGroup)
        {
            var group = new Group();
            group.Id = rpcGroup.Id;
            group.AvatarUrl = rpcGroup.AvatarUrl;
            group.CreatedAt = rpcGroup.CreatedAt;
            group.Description = new LocalizableText(rpcGroup.GroupDescription).LocalizedValue();
            group.FollowersCount = rpcGroup.FollowersCount;
            group.IsFollowedByMe = rpcGroup.IsFollower;
            group.MembersCount = rpcGroup.MembersCount;
            group.Membership = rpcGroup.Membership.FromRPCModel();
            group.Settings = rpcGroup.Settings.FromRPC();
            group.Title = new LocalizableText(rpcGroup.Title).LocalizedValue();
            group.UpdatedAt = rpcGroup.UpdatedAt;
            return group;
        }

        public static GroupMember FromRPCModel(this SGGroupMember rpcGroupMember)
        {
            var member = (GroupMember)(rpcGroupMember.User.FromRPCModel());
            member.Membership = rpcGroupMember.Membership.FromRPCModel();
            return member;
        }

        public static Pagination ToPagination<T>(this PagingQuery<T> query)
        {
            return new Pagination
            {
                Limit = query.Limit,
                NextCursor = query.NextCursor
            };
        }

        public static PagingResult<T> FromRPCModel<R, T>(List<R> entries, string next, Converter<R, T> convert)
        {
            return new PagingResult<T>
            {
                Entries = (entries ?? new List<R>()).ConvertAll(convert), NextCursor = next ?? ""
            };
        }

        public static PagingResult<Notification> FromRPCModel(this GetNotificationsResponse response)
        {
            var users = response.Authors;
            return FromRPCModel(response.Notifications, response.NextCursor, notification =>
            {
                var id = notification.Sender.PublicUser?.Id;
                var user = id != null && users.ContainsKey(id) ? users[id] : null;
                return FromRPCModel(notification, user);
            });
        }

        private static Notification FromRPCModel(PNNotification notification, THPublicUser user)
        {
            if (user == null)
            {
                user = notification.Sender.PublicUser;
            }

            return new Notification
            {
                Id = notification.Id,
                Customization = new NotificationCustomization
                {
                    BackgroundImageConfiguration = notification.Media?.BackgroundImage,
                    TextColor = notification.Media?.TextColor,
                    TitleColor = notification.Media?.TitleColor
                },
                ActionButtons = (notification.ActionButtons ?? new List<THActionButton>()).ConvertAll(it => it.FromRpcModel()),
                Attachment = null, // todo
                CreatedAt = notification.CreatedAt,
                Action = notification.Action?.FromRpcModel(),
                Sender = user.FromRPCModel(),
                Type = notification.Type,
                Status = notification.Status,
                Text = notification.Text,
                Title = notification.Title
            };
        }

        public static PagingResult<Topic> FromRPCModel(this GetTopicsResponse response)
        {
            return FromRPCModel(response.Topics, response.NextCursor, FromRPCModel);
        }

        public static PagingResult<GroupMember> FromRPCModel(this GetGroupMembersResponse response)
        {
            return FromRPCModel(response.Members, response.NextCursor, FromRPCModel);
        }

        public static PagingResult<Group> FromRPCModel(this GetGroupsResponse response)
        {
            return FromRPCModel(response.Groups, response.NextCursor, FromRPCModel);
        }

        public static PagingResult<User> FromRPCModel(this GetEntityFollowersResponse response)
        {
            return FromRPCModel(response.Followers, response.NextCursor, FromRPCModel);
        }
        
        public static PagingResult<UserReactions> FromRPCModel(this GetReactionsResponse response)
        {
            return FromRPCModel(response.Reactions, response.NextCursor, FromRPCModel);
        }

        public static UserReactions FromRPCModel(this AFReaction reaction)
        {
            return new UserReactions { User = reaction.Creator.FromRPCModel(), ReactionsList = reaction.Reactions};
        }

        public static MembershipInfo FromRPCModel(this SGMembershipInfo rpcMembership)
        {
            var info = new MembershipInfo();
            info.CreatedAt = rpcMembership.CreatedAt;
            info.InvitationToken = rpcMembership.InvitationToken;
            info.Role = MembershipRoleFromRPCModel(rpcMembership.Role);
            info.Status = MembershipStatusFromRPCModel(rpcMembership.Status);
            return info;
        }

        public static MembershipRole MembershipRoleFromRPCModel(int rawValue)
        {
            switch (rawValue)
            {
                case 0:
                    return MembershipRole.Owner;
                case 1:
                    return MembershipRole.Admin;
                case 2:
                    return MembershipRole.Member;
                default:
                    return MembershipRole.Unknown;
            }
        }

        public static MembershipStatus MembershipStatusFromRPCModel(int rawValue)
        {
            switch (rawValue)
            {
                case 0:
                    return MembershipStatus.ApprovalPending;
                case 1:
                    return MembershipStatus.InvitationPending;
                case 2:
                    return MembershipStatus.CompleteMember;
                default:
                    return MembershipStatus.Unknown;
            }
        }

        public static Dictionary<string, MembershipRole> FromRPCModel(this AreMembersResponse response)
        {
            var result = new Dictionary<string, MembershipRole>();
            foreach (var entry in response.Result)
            {
                result[entry.Key] = MembershipRoleFromRPCModel(entry.Value.Role);
            }
            return result;
        }

        public static Dictionary<string, bool> FromRPCModel(this IsFollowingResponse response)
        {
            return response.Result;
        }

        #endregion

        #region Promo codes

        public static CreatePromoCodeRequest ToRPC(this PromoCodeContent content)
        {
            var request = new CreatePromoCodeRequest();

            var code = new SIPromoCode();
            code.MaxClaims = (int)content.MaxClaimCount;
            code.Code = content.Code;
            code.Properties = content.Data;
            if (content._startDate != 0) 
            {
                code.ValidFrom = content._startDate;
            }
            if (content._endDate != 0) 
            {
                code.ValidUntil = content._endDate;
            }

            request.Code = code;
            return request;
        }

        public static PromoCode FromRPC(this CreatePromoCodeResponse response)
        {
            return response.Code.FromRPC();
        }

        public static PromoCode FromRPC(this GetPromoCodeResponse response)
        {
            return response.Code.FromRPC();
        }

        public static PromoCode FromRPC(this ClaimPromoCodeResponse response)
        {
            return response.Code.FromRPC();
        }

        public static PromoCode FromRPC(this SIPromoCode promoCode)
        {
            var result = new PromoCode();
            result.Code = promoCode.Code;
            result.Creator = promoCode.Creator.FromRPCModel();
            result.Properties = promoCode.Properties;
            result.StartDate = promoCode.ValidFrom;
            result.EndDate = promoCode.ValidUntil;
            result.IsClaimable = promoCode.Claimable;
            result.IsEnabled = promoCode.Enabled;
            result.ClaimCount = (uint)promoCode.NumClaims;
            result.MaxClaimCount = (uint)promoCode.MaxClaims;

            return result;
        }

        #endregion
    }
}
#endif
