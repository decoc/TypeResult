# TypeResult

TypeResult is a utility for easily describing results with values ​​and errors like `Either Monado`.
It is limited to returning results by OK() or Fail() methods as follows.

```cs

var result = Results.Ok();
var result = Results.Ok(100);
var result = Results.Fail("Reason");
var result = Results.Fail<MyError>(new MyError.Case1("Reason"));

```

Since `Error` class is defined, you can process error using switch statement.

```cs
switch (result.Error)
{
    case MyError.Case1 case1:
        Assert.AreEqual("Reason", case1.Reason);
        break;
    default:
        Assert.Fail();
        break;
}
```

## Tuple support

There is also support for converting the Results type to Tuple, so you can also write as follows.

```cs

var (val, error) = Results.Ok();
var (val, error) = Results.Fail<MyError>(new MyError.Case1("Reason"));

```

## Result Extension

### OnSuccess, OnFailure

Since Result can be connected to the process when it succeeds and the process when it fails, the annoyance of the if statement can be eliminated.

```cs

var result = Results.Ok(100)
    .OnSuccess(val => Assert.AreEqual(100, val))
    .OnFailure(_ => Assert.Fail());

var result = Results.Fail("Reason")
    .OnSuccess(_ => Assert.Fail())
    .OnFailure(e => Assert.AreEqual("Reason",e.Reason));

```

### FluentStyle

You can smoothly convert from Results.Ok and Results.Fail to Result type with Value and Error.

```cs
Results.Ok()
    .WithValue(100)
    .OnSuccess(val => Assert.AreEqual(100, val))
    .OnFailure(_ => Assert.Fail());

Results.Fail()
    .WithErrorMessage("Reason")
    .OnSuccess(_ => Assert.Fail())
    .OnFailure(e => Assert.AreEqual("Reason", e.Reason));
```

[Base Idia](https://medium.com/@michael_altmann/error-handling-returning-results-2b88b5ea11e9)

## Reults Extension

You can process only successful or failure results from multiple results.

```cs
var results = new List<Result<int, Error>>()
{
    Result.Ok<int, Error>(1),
    Result.Fail<int, Error>(new Error()),
    Result.Ok<int, Error>(100)
};

results
    .OnSuccessAny(_ => Assert.Pass());

var successes = results.FilterSuccess();

```
