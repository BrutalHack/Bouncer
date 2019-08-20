# Bouncer
Bouncer provides lightweight runtime-only "contracts" for .Net applications. 
Focus lies on readability and extensibility.

# Build Status

| Framework | Status|
|--|--|
| .Net Core 2.1 | [![Build Status](https://travis-ci.org/BrutalHack/Bouncer.svg?branch=master)](https://travis-ci.org/BrutalHack/Bouncer) |

## Usage

Import the Nuget Package and check constraints for your methods parameters in a few readable lines.
When a constraint is violated, you receive a readable exception including stack trace.

### with Bouncer
```cs
IBouncer Bouncer;

public CreateNewUser(string name, int age)
{
  Bouncer.IsNotNullOrEmpty(name);
  Bouncer.IsPositive(age)
  // Do Stuff
}
```

### without Bouncer
```cs
public CreateNewUser(string name, int age)
{
  if (name == null)
  {
    throw new ArgumentNullException(nameof(name), "Must not be null.");
  }
  if (name.length == 0)
  {
    throw new ArgumentOutOfRangeException(nameof(name), "Must not be empty.");
  }
  if (age < 0)
  (
    throw new ArgumentOutOfRangeException(nameof(age), "Must be positive.");
  }
  
  // Do Stuff
}
```

## Planned Features

- More constraints
- Easily disable all constraints in production mode
- Guide on extending Validate with your own constraints

## Naming

We finally found a name that we like!
