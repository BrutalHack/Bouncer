# Bouncer
Bouncer provides lightweight runtime-only "contracts" for .Net applications. 
Focus lies on readability, extensibility and a high unit test coverage.

[![Travis (.org)](https://img.shields.io/travis/BrutalHack/Bouncer)](https://travis-ci.org/BrutalHack/Bouncer) [![Nuget](https://img.shields.io/nuget/v/BrutalHack.Bouncer?color=green)](https://www.nuget.org/packages/BrutalHack.Bouncer/) [![Discord](https://img.shields.io/discord/371412787731103746?label=Discord)](https://discord.gg/4FmEwGp)

- [Usage](#usage)
  * [with Bouncer](#with-bouncer)
  * [without Bouncer](#without-bouncer)
- [Custom Rules](#custom-rules)
  * [Using Extension Methods](#using-extension-methods)
  * [Using IsTrue](#using-istrue)
- [Planned Features](#planned-features)

# Usage

Import the Nuget Package and check constraints for your methods parameters in a few readable lines.
When a constraint is violated, you receive a readable exception including stack trace.

## with Bouncer
```cs
IBouncer Bouncer;

public CreateNewUser(string name, int age)
{
  Bouncer.IsNotNullOrEmpty(name);
  Bouncer.IsPositive(age)
  // Do Stuff
}
```

## without Bouncer
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

# Custom Rules

## Using Extension Methods

Bouncer is easily extendible via C# Extension Methods.
By extending `IBouncer`, your methods are available to all Bouncer instances retrieved via Bouncer.Instance or via  Dependency Injection.

Example:
```cs
using System;
using System.Collections.Generic;

namespace BrutalHack.Bouncer
{
    public static class BouncerExtensions
    {
        /// <summary>
        /// Validates if a collection contains the given elements
        /// </summary>
        /// <param name="bouncer"></param>
        /// <param name="element"></param>
        /// <param name="collection"></param>
        /// <typeparam name="T">Generic Type of the given list</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">thrown, when the list does not contain the given element.</exception>
        public static void Contains<T>(this IBouncer bouncer, T element, ICollection<T> collection)
        {
            if (!collection.Contains(element))
            {
                throw new ArgumentOutOfRangeException($"Collection {collection} must contain Element {element}.");
            }
        }
    }
}
```

Extension methods are used like normal methods on IBouncer:

```cs
var collection = new List<string>{"foo", "bar"};
_bouncer.Contains("not included", collection);
```

## Using IsTrue

For rules, which are only needed once, you may also use IsTrue with a boolean expression.

We do not recommend this approach, as it can easily create duplicate code.

```cs
var collection = new List<string>{"foo", "bar"};
_bouncer.IsTrue(collection.Contains("not included"));
```

# Planned Features

- More constraints
- Easily disable all constraints in production mode
