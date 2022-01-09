![StepsInSpace](assets/logo.png) 

# StepsInSpace

My goal is to build a simple cross-platform game engine with some physics, collision detection and 3D graphics driven by the [OpenTK](https://opentk.net/) framework.
Finally, it should end in a simple 3D driving simulation with a track editor like the game "Stunts" of the great early days of 3D gaming.

## Prerequisites

* Download and install dotnet 6.0 SDK, further details see [Download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* Download and install your favorite IDE to edit & compile C# projects, e.g. [MS Visual Studio 2022 Community Edition (free of charge)](https://visualstudio.microsoft.com/) or [MS Visual Studio Code (free of charge)](https://visualstudio.microsoft.com/) or [JetBrains Rider (payable)](https://www.jetbrains.com/rider/)
* Clone the repository [StepsInSpace](https://github.com/SteffenRossberg/StepsInSpace.git)

## Build

1. Go to repository ```./src``` folder in your favorite shell
2. Run ```dotnet restore StepsInSpace.sln``` to restore dependencies (nuget packages)
3. Run ```dotnet build StepsInSpace.sln``` to build all solution projects

## Test
1. Go to repositories ```./src``` folder in your favorite shell
2. Run ```dotnet test StepsInSpace.sln``` to all tests of solution
