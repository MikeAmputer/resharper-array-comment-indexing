# ArrayCommentIndexing for Rider and ReSharper

[![Rider](https://img.shields.io/jetbrains/plugin/v/com.github.mikeamputer.arraycommentindexing.svg?label=Rider&colorB=0A7BBB&style=for-the-badge&logo=rider)](https://plugins.jetbrains.com/plugin/26764-array-comments-indexing)
[![ReSharper](https://img.shields.io/jetbrains/plugin/v/ReSharperPlugin.ArrayCommentIndexing.svg?label=ReSharper&colorB=0A7BBB&style=for-the-badge&logo=resharper)](https://plugins.jetbrains.com/plugin/26757-array-comment-indexing)

<img src="https://github.com/MikeAmputer/resharper-array-comment-indexing/blob/master/img/example.png" alt="Code example" title="Code example" width="512">

Sometimes you have to use indexed placeholders with `string.Format()` and [you are not alone](https://github.com/dotnet/runtime/discussions/100259). Keeping track of array element positions can be difficult. This plugin helps maintain clarity by adding and updating index comments via Context Actions.

## Getting Started
1. Install the plugin from the JetBrains Marketplace (an IDE restart may be required).
2. Open the `Context Actions` menu (**Alt+Enter**) inside an array initializer.
3. Select `Add Index Comments to Array Elements` to annotate the array with index comments.
4. To update indexes, run the action again.

## Build
Run `./gradlew buildPlugin` from the solution root directory. The `output` directory will contain two files:
- `.nupkg` for ReSharper
- `.zip` for Rider.
