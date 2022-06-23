# Single linked circular list

This project observes how to implement single linked circular list data struct basic operations, test them with unit tests and Github Actions CI/CD.

Unit testing library: xUnit.net ([link](https://xunit.net/))

## Quick Start

**Firstly, you need to install .NET Core on your PC** ([instructions here](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu))

Example (Ubuntu 20.04 LTS):
```
$ wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

$ sudo dpkg -i packages-microsoft-prod.deb

$ rm packages-microsoft-prod.deb
```

**To build the project you need to go forward into solution directory and run:**

```
$ dotnet restore

$ dotnet build
```

**You can simply run tests with:**

```
$ dotnet test
```
## Failed test (CI/CD)

The most fail test commit ever is hiding [here](https://github.com/gurug-prog/circular-linked-list/commit/5cd31ee7ba7b1a31bf9378f2dda7e1c8f01eacbd)

## License

MIT
