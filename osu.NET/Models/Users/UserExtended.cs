using Newtonsoft.Json;
using osu.NET.Enums;

namespace osu.NET.Models.Users;

/// <summary>
/// Represents an extended osu! user, inheriting from <see cref="User"/> and including additional properties.
/// The API differs between "normal" beatmaps and "extended" users, as not all information is available on all endpoints.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#userextended"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/user-extended-json.ts"/>
/// </summary>
public class UserExtended : User
{
  /// <summary>
  /// The Discord name of this user. This will be null if this user has not set their Discord name.
  /// </summary>
  [JsonProperty("discord")]
  public string? Discord { get; private set; }

  /// <summary>
  /// Bool whether the user has had a supported tag before.
  /// </summary>
  [JsonProperty("has_supported")]
  public bool HasSupported { get; private set; }

  /// <summary>
  /// The specified interests of this user. This will be null if this user has not set their interests.
  /// </summary>
  [JsonProperty("interests")]
  public string? Interests { get; private set; }

  /// <summary>
  /// The datetime at which this user joined osu!.
  /// </summary>
  [JsonProperty("join_date")]
  public DateTimeOffset JoinDate { get; private set; }

  /// <summary>
  /// The specified location of this user. This will be null if this user has not set their location.
  /// </summary>
  [JsonProperty("location")]
  public string? Location { get; private set; }

  /// <summary>
  /// The maximum amount of blocks this user can have.
  /// </summary>
  [JsonProperty("max_blocks")]
  public int MaxBlocks { get; private set; }

  /// <summary>
  /// The maximum amount of friends this user can have.
  /// </summary>
  [JsonProperty("max_friends")]
  public int MaxFriends { get; private set; }

  /// <summary>
  /// The occupation of this user. This will be null if this user has not set their occupation.
  /// </summary>
  [JsonProperty("occupation")]
  public string? Occupation { get; private set; }

  /// <summary>
  /// The primary ruleset of this user.
  /// </summary>
  [JsonProperty("playmode")]
  public Ruleset Ruleset { get; private set; }

  /// <summary>
  /// The specified playstyles of this user.
  /// </summary>
  [JsonProperty("playstyle")]
  public Playstyle[] Playstyle { get; private set; } = default!;

  /// <summary>
  /// The amount of forum posts this user has made.
  /// </summary>
  [JsonProperty("post_count")]
  public int PostCount { get; private set; }

  /// <summary>
  /// The hue of this users' profile in HSL degrees. This will be null if the user has not set their profile hue.
  /// </summary>
  [JsonProperty("profile_hue")]
  public int? ProfileHue { get; private set; }

  /// <summary>
  /// The order of the sections on this users' profile.
  /// </summary>
  [JsonProperty("profile_order")]
  public ProfileSection[] ProfileOrder { get; private set; } = default!;

  /// <summary>
  /// The title of this user. This will be null if this user has not title.
  /// </summary>
  [JsonProperty("title")]
  public string? Title { get; private set; }

  /// <summary>
  /// The URL to the origin of this users' title. This will be null if this user has no title.
  /// </summary>
  [JsonProperty("title_url")]
  public string? TitleUrl { get; private set; }

  /// <summary>
  /// The twitter name of this user. This will be null if this user has not set their Twitter name.
  /// </summary>
  [JsonProperty("twitter")]
  public string? Twitter { get; private set; }

  /// <summary>
  /// The URL to the users' website. This will be null if this user has not set their website URL.
  /// </summary>
  [JsonProperty("website")]
  public string? Website { get; private set; }
}
