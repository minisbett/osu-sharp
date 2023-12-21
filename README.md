<div align="center">

# osu-sharp

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![Latest Release](https://img.shields.io/github/v/release/minisbett/osu-sharp?color=ff87c6)](https://github.com/minisbett/osu-sharp/releases/latest)

A comprehensive, well documented API wrapper for the public scope of the osu! API v2.<br/>
This wrapper <ins>currently only supports client credential authentication</ins>.<br/>

[Getting Started](#getting-started) • [Endpoints](#features)<br/>
</div>

<div align="center">
<i>Made with ❤️ by minisbett</i>
</div>

# Getting Started

The methods for accessing the API can be found in the `OsuApiClient` class. When creating an instance, you will need to specify the client ID and client secret, as found in your [osu! settings](https://osu.ppy.sh/home/account/edit#oauth).  
Authorization using an OAuth flow or user credentials is not supported *yet*, but is planned for the future.  

Below, you can find a simple example on how to authenticate using client credentials and request info about a beatmapset.
```cs
// Create the client.
OsuApiClient client = new OsuApiClient(clientId, clientSecret);

// Optional. Requests an access token using the specified client credentials.
// This action is automatically performed whenever calling an API endpoint.
client.EnsureAccessToken();

// Get Sotarks' Harumachi Clover.
BeatmapSetExtended? set = await client.GetBeatmapSetAsync(842412);
```

Every model and every endpoint method is well documented, containing both references to the API documentation and osu-web source code, as well as notes found in the API documentation. If you believe you've found an inconsistency, for example due to changes to the API, please let me know in the GitHub Issues.

## Asynchronous Enumerables for pagination

For API endpoints that have pagination, osu-sharp provides an `IAsyncEnumerable` allowing you to treat the data received from the endpoint as an enumerable. It automatically performs further pagination requests as necessary, making working with it very easy and straight-forward. Below, you can find an example.
```cs
// Create the client.
OsuApiClient client = new OsuApiClient(clientId, clientSecret);

// Get the async enumerable for beatmap packs.
IAsyncEnumerable<BeatmapPack> packs = client.GetBeatmapPacksAsync();

// Enumerate over all beatmap packs and output their tag.
await foreach (BeatmapPack pack in packs)
  Console.WriteLine(pack.Tag);
```

## Normal & Extended models

The osu! API splits it's models for beatmaps, beatmapsets and users, the normal size (`Beatmap`, `BeatmapSet`, `User`), and their extended version, containing more fields with information (`BeatmapExtended`, `BeatmapSetExtended`, `UserExtended`). It is advised to utilize the API documentation when using the API wrapper, to make sure you get the necessary information you require.

Below, you can find the API documentation for each model:  
[Beatmap](https://osu.ppy.sh/docs/index.html#beatmap) • [BeatmapExtended](https://osu.ppy.sh/docs/index.html#beatmapextended)  
[BeatmapSet](https://osu.ppy.sh/docs/index.html#beatmapset) • [BeatmapSetExtended](https://osu.ppy.sh/docs/index.html#beatmapsetextended)  
[User](https://osu.ppy.sh/docs/index.html#user) • [UserExtended](https://osu.ppy.sh/docs/index.html#userextended)

# Features

Below, you can find a list of all endpoints available on the osu! API v2, as well as a checkmark on those that have been implemented.
```
Beatmap Packs (100% 2/2)
  [✓] /beatmaps/packs
  [✓] /beatmaps/packs/{tag}

Beatmaps (100% 7/7)
  [✓] /beatmaps
  [✓] /beatmaps/lookup
  [✓] /beatmaps/{beatmap}
  [✓] /beatmaps/{beatmap}/attributes
  [✓] /beatmaps/{beatmap}/scores
  [✓] /beatmaps/{beatmap}/scores/users/{user}
  [✓] /beatmaps/{beatmap}/scores/users/{user}/all

Beatmap Sets (100% 2/2)
  [✓] /beatmapsets/lookup
  [✓] /beatmapsets/{beatmapset}

Changelogs (100% 3/3)
  [✓] /changelog
  [✓] /changelog/{buildOrStream}
  [✓] /changelog/{stream}/{build}

Comments (100% 2/2)
  [✓] /comments
  [✓] /comments/{comment}

Events (0% 0/1)
  [ ] /events

Forum (100% 1/1)
  [✓] /forums/topics/{topic}

Home (0% 0/1)
  [ ] /search

Multiplayer (0% 0/1)
  [ ] /rooms/{room}/playlist/{playlist}/scores

News (0% 0/2)
  [ ] /news
  [ ] /news/{news}

Ranking (0% 0/3)
  [ ] /rankings/kudosu
  [ ] /rankings/{mode}/{type}
  [ ] /spotlights

Users (0% 0/6)
  [ ] /users
  [ ] /users/{user}/{mode?}
  [ ] /users/{user}/kudosu
  [ ] /users/{user}/scores/{type}
  [ ] /users/{user}/beatmapsets/{type}
  [ ] /users/{user}/recent_activity

Wiki (0% 0/1)
  [ ] /wiki/{locale}/{path}
```
