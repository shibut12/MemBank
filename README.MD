# MEMBANK

*MemBank* is a Cross-platform .Net core library, which implement an in-memory bank with basic banking functionalities. This library showcase the use of Object-Oriented programming, Factory, and Mediator design patterns in C#.
#### Build and Test coverage status
[![Cross platform Build Status](https://travis-ci.org/shibut12/MemBank.svg?branch=master)](https://travis-ci.org/shibut12/MemBank) [![Visual Studio build status](https://ci.appveyor.com/api/projects/status/d4sbcxjuevtmk80y?svg=true)](https://ci.appveyor.com/project/shibut12/membank/branch/master) [![codecov](https://codecov.io/gh/shibut12/MemBank/branch/master/graph/badge.svg)](https://codecov.io/gh/shibut12/MemBank)

##### Plug: [Link to my blog - CodewithDot.net](http://www.codewithdot.net)
### Objective
* Create an Object Oriented Program
* Utilize Design patterns
* Program should not have an interface
* Should implement test classes to validate requirements
### Requirements
* A bank has a name.
* A bank also has several accounts.
* An account has an owner and a balance.
* Account types include: Checking, Investment.
* There are two types of Investment accounts: Individual, Corporate.
* Individual accounts have a withdrawal limit of 500 dollars.
* Transactions are made on accounts.
* Transaction types include: Deposit, Withdraw, and Transfer
### Technology stack
* .Net Core 2.0.2
* XUnit.Net
### Continuous Integration
 * Cross platform build is done on Ubuntu 14.04 using [Travis CI](https://travis-ci.org)
 * Build on Windows is done using Visual studio 2017 on [AppVeyor](https://www.appveyor.com)
   * Code Coverage report is generated using [OpenCover](https://github.com/OpenCover/opencover)
 * Code coverage monitored per build is performed using [codecov.io](https://codecov.io)
### How to run
```shell
git clone https://github.com/shibut12/MemBank.git
dotnet restore
dotnet build
dotnet test
opencover\4.6.519\tools\OpenCover.Console.exe -target:"dotnet.exe" -targetargs:" test " -register:user -oldStyle -output:opencoverCoverage.xml
```
