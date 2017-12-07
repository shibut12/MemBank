# MEMBANK
A Cross-platform .Net core library, which implement an in-memory bank with basic banking functionalities. This library showcase the use of Object-Oriented programming, Factory, and Mediator design patterns in C#.
---
#### Cross platform build (Ubuntu 14.04)
[![Cross platform Build Status](https://travis-ci.org/shibut12/MemBank.svg?branch=master)](https://travis-ci.org/shibut12/MemBank) [![Visual Studio build status](https://ci.appveyor.com/api/projects/status/vr33idjftiw3fa46/branch/master)](https://ci.appveyor.com/project/shibut12/membank/branch/master) [![codecov](https://codecov.io/gh/shibut12/MemBank/branch/master/graph/badge.svg)](https://codecov.io/gh/shibut12/MemBank)
---
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

### How to run
```shell
git clone https://github.com/shibut12/MemBank.git
dotnet restore
dotnet build
dotnet test
```
