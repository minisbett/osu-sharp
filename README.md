<div align="center">

# osu-sharp

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![Latest Release](https://img.shields.io/github/v/release/minisbett/osu-sharp?color=ff87c6)](https://github.com/minisbett/osu-sharp/releases/latest)

A comprehensive, well documented API wrapper for the osu! API v2.<br/>
This wrapper <ins>currently only supports publis scope endpoints</ins>.<br/>

[Getting Started](#getting-started) • [Error Handling](#error-handling) • [Contribute](#contribute) • [API Coverage](#api-coverage)<br/>
</div>

<div align="center">
<i>Made with ❤️ by minisbett for the osu! community</i>
</div>

# Getting Started

This wrapper is meant to be integrated into [.NET Generic Host](https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder). It can also be used standalone, an overview on how to get started without the .NET Generic Host can be found [further below](#stand-alone-usage).

Every model and every endpoint is well documented, including:
- Documentation of [almost](#contribute) every property and parameter, beyond what the official osu! API documentation provides
- References to the osu! API documentation & osu-web source-code
- API notes found in the official osu! API documentation
- Information on what API errors to expect on each endpoint

As for the authorization flow, there are multiple `IOsuAccessTokenProvider` to choose from:
| IOsuAccessTokenProvider    | Authorization Flow | Usage |
| -------- | ------- | ------- |
| `OsuClientAccessTokenProvider`  | Authorization using client ID & secret    | `new(id, secret)`<br/> `.FromEnvironmentVariables(id, secret)` |
| `OsuStaticAccessTokenProvider` | Authorization using a static access token     | `new(accessToken)` |
| `OsuDelegateAccessTokenProvider`    | Authorization using an access token provided via a delegate (eg. for fetching from a database)    | `new(cancellationToken => ...)`

> [!TIP]
> You can also write your own access token provider by inheriting `IOsuAccessTokenProvider`, and use it to register the service.

## Using the .NET Generic Host
The API wrapper provides an extension method for registering the `OsuApiClient`. It is registered as a scoped service, and the access tokens are provided via a singleton `IOsuAccessTokenProvider`. Optionally, the API client can be configured.

Here is an example on how to register an `OsuApiClient`:
```cs
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.AddSimpleConsole();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<TestService>();
        services.AddOsuApiClient(OsuClientAccessTokenProvider.FromEnvironmentVariables("OSU_ID", "OSU_SECRET"), (options, _) =>
        {
            options.EnableLogging = true;
        });
    })
  .Build();
```
The `OsuApiClient` can then be consumed via dependency injection:
```cs
public class TestService(OsuApiClient client) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        APIResult<UserExtended> result = await client.GetUserAsync("mrekk", cancellationToken);
    }
}
```

## Stand-alone usage
To use the `OsuApiClient` without the .NET Generic Host, there are some criteria to be considered, as this library was primarily designed with it in mind.

Briefly said, you create an instance of the `IOsuAccessTokenProvider` providing the desired authorization flow, and using that you create an instance of the `OsuApiClient`:
```cs
OsuClientAccessTokenProvider provider = OsuClientAccessTokenProvider.FromEnvironmentVariables("OSU_ID", "OSU_SECRET");

OsuApiClientOptions options = new()
{
    EnableLogging = false // false by default, do *not* set it to true for stand-alone usage
};

OsuApiClient client = new(provider, options, null! /* ILogger instance, set to null for stand-alone usage*/);
```
> [!IMPORTANT]
> Since the logging is based on the `Microsoft.Extensions.Logging.ILogger<T>`, logging needs to be disabled and the logger set to null.

# Error Handling

The response returned from the endpoint methods are of type `APIResult<T>`. This type wraps the data returned from the osu! API, or provides the error if the API returned one. Additionally, osu-sharp interprets the error message provided by the osu! API and provides an `APIErrorType` for common errors. This can help handle different kinds of errors in individual ways.

> [!TIP]
> The xmldoc for the entrypoint methods always provides the `APIErrorType` the endpoints are known to return, as well as when they do it, so you always know which errors to expect.

Here is an example:
```cs
APIResult<UserBeatmapScore> result = await client.GetUserBeatmapScoreAsync(4697929, 7981241, cancellationToken: cancellationToken);
if (result.IsSuccess)
    logger.LogInformation("PP: {PP}", result.Value!.Score.PP);
else if (result.Error.Type is APIErrorType.BeatmapNotFound)
    logger.LogError("Beatmap not found.");
else if (result.Error.Type is APIErrorType.UserOrScoreNotFound)
    logger.LogError("The user was not found or has no scores on the beatmap.");
else
    logger.LogError("{Message}", result.Error.Message);
```

# Contribute

This library is very maintanence-intensive, as it provides a lot of detailed documentation. If you'd like to help adding documentation to the few parts that are currently not documented, or you found an incorrect documentation, feel free to create an issue or open a pull request!

As for the API coverage and keeping the API models up-to-date, feel free to propose/report (via an issue) or even implement (via a pull request) new or outdated endpoints or API models. I greatly appreciate any help in keeping this API wrapper updated and easy-to-use.

# API Coverage

Here's a list of all planned and implemented osu! API endpoints. If you'd like to suggest a missing endpoint, or want to add one yourself, feel free to create an issue or pull request.
```
Beatmap Packs (1/2)
  [ ] /beatmaps/packs
  [✓] /beatmaps/packs/{tag}

Beatmaps (8/8)
  [✓] /beatmaps?id[]
  [✓] /beatmaps/lookup?checksum
  [✓] /beatmaps/lookup?filename
  [✓] /beatmaps/{beatmap}
  [✓] /beatmaps/{beatmap}/attributes
  [✓] /beatmaps/{beatmap}/scores
  [✓] /beatmaps/{beatmap}/scores/users/{user}
  [✓] /beatmaps/{beatmap}/scores/users/{user}/all

Beatmap Sets (2/2)
  [✓] /beatmapsets/lookup
  [✓] /beatmapsets/{beatmapset}

Changelogs (3/3)
  [✓] /changelog
  [✓] /changelog/{buildOrStream}
  [✓] /changelog/{stream}/{build}

Comments (1/2)
  [ ] /comments
  [✓] /comments/{comment}

Events (0/1)
  [ ] /events

Forums (0/4)
  [ ] /forums/topics
  [ ] /forums/topics/{topic}
  [ ] /forumsy
  [ ] /forums/{forum}

Home (0/1)
  [ ] /search

Matches (0/2)
  [ ] /matches
  [ ] /matches/{match}

Multiplayer (0/1)
  [ ] /rooms/{room}/playlist/{playlist}/scores

News (2/3)
  [ ] /news
  [✓] /news/{news}
  [✓] /news/{news}?id

Rankings (2/3)
  [✓] /rankings/kudosu
  [ ] /rankings/{mode}/{type}
  [✓] /spotlights

Scores (0/1)
  [ ] /scores

Users (6/6)
  [✓] /users/{user}/kudosu
  [✓] /users/{user}/scores/{type}
  [✓] /users/{user}/beatmapsets/{type}
  [✓] /users/{user}/recent_activity
  [✓] /users/{user}/{mode?}
  [✓] /users?id[]

Wiki (1/1)
  [✓] /wiki/{locale}/{path}
```