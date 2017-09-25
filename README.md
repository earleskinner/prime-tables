# Prime tables

> An application that takes numeric input `n` from a user and outputs a multiplication table of `n+1 x n+1` prime numbers.

First and foremost, I would like to state that I am not a mathematician. Although, I know the "trial by divison" algorithm, the requirement was not to use this. After some research, I found the [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) to be the best way to generate large sets of prime numbers. I also want to mention [starblue](https://stackoverflow.com/questions/1042902/most-elegant-way-to-generate-prime-numbers) for his guidance on generating approximate prime numbers.

## Features

- It's quick! On a Core i7 4.5Ghz machine it takes **~250ms** to generate **1 million** prime numbers
- The application averages around 3% CPU and 300MB memory
- The application can be extended for inputs, outputs and generators
- The application has decent memory efficiency

## Requirements

The following is required to develop/execute this application:
- .NET Framework 4.6.1 runtime
- Visual Studio 2015 or later

## Installation

To build this application outside of Visual Studio, run the following commands:

```powershell
# myapp contains the files downloaded from this repo
> cd .\myapp\
> c:\windows\microsoft.net\framework\v4.0.30319\msbuild.exe .\src\PrimeTables.Console\PrimeTables.Console.csproj /t:Build /p:Configuration=Release
```

The application is now ready to be executed.

## Execution

** WARNING! Use at your own risk** I have tested up to 1 million prime numbers but results pass this can potentially break your machine. I myself managed to hit 100% CPU and use all 32GB of ram on my machine.

```powershell
# myapp would now contain the compiled application
> cd .\myapp\src\PrimeTables.Console\bin\Release\
> .\pt.exe [number] # A positive integer without the square brackets. For example: 1000
```

Dependant on the number you have choose, your screen should now be flooded with numbers :)

## Improvements

- Allow the `IInput` interface to decide which prime number generator to use
- Add more types of generators (i.e Sieve of Sundaram or Sieve of Atkin) to compare results
- Find a more efficient way to output console text
- Write unit tests to compare multiple generators
- Introduce a break mechanic to stop generation or output at any time
- Find a better way to deal with generating large amounts of prime numbers (i.e over 1 trillion)
  - Possibly multiple async processes
