using Newtonsoft.Json;
using osu_sharp.Converters;
using osu_sharp.Enums;
using osu_sharp.Models.Beatmaps.Discussions;
using osu_sharp.Models.Users.Events;

namespace osu_sharp;

/// <summary>
/// Provides the <see cref="JsonSerializerSettings"/> for the <see cref="OsuApiClient"/>.
/// </summary>
internal class OsuSharpJsonSerializer : JsonSerializer
{
  public override JsonConverterCollection Converters { get; } = [
    new EnumConverter(),

    //
    // Deserializes UserEvent objects into their correct type based on the UserEventType
    //
    new TypeMappingConverter<UserEvent>(obj =>
    {
      return obj.Type switch
      {
        UserEventType.Achievement => typeof(AchievementEvent),
        UserEventType.BeatmapPlaycount => typeof(BeatmapPlaycountEvent),
        UserEventType.BeatmapsetApprove => typeof(BeatmapsetApproveEvent),
        UserEventType.BeatmapsetDelete => typeof(BeatmapsetDeleteEvent),
        UserEventType.BeatmapsetRevive => typeof(BeatmapsetReviveEvent),
        UserEventType.BeatmapsetUpdate => typeof(BeatmapsetUpdateEvent),
        UserEventType.BeatmapsetUpload => typeof(BeatmapsetUploadEvent),
        UserEventType.Rank => typeof(RankEvent),
        UserEventType.RankLost => typeof(RankLostEvent),
        UserEventType.UserSupportAgain => typeof(UserSupportAgainEvent),
        UserEventType.UserSupportFirst => typeof(UserSupportFirstEvent),
        UserEventType.UserSupportGift => typeof(UserSupportGiftEvent),
        UserEventType.UsernameChange => typeof(UsernameChangeEvent),
        _ => throw new NotImplementedException($"{nameof(UserEventType)} '{obj.Type}' is not implemented.")
      };
    }),
        
    //
    // Deserializes DiscussionPost objects into their correct type based on whether its a system message
    //
    new TypeMappingConverter<DiscussionPost>(obj =>
    {
      return obj.IsSystemMessage switch
      {
        true => typeof(SystemDiscussionPost),
        false => typeof(UserDiscussionPost)
      };
    })
  ];
}