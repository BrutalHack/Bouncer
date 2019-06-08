# Contracts
Lightweight Runtime-Only Contracts for .Net Applications. Focus lies on Readability and Extensibility

## Usage

Import the Nuget Package and check constraints for your methods parameters in a few readable lines.

When a constraint is violated, you receive a readable exception including stack trace.

### with BrutalHack.Contracts
```cs
protected Tile(int cornerCount, float outerRadius, Vector2Int position, int height, float heightFactor = 1f)
{
  Validate.IsPositive(cornerCount);
  Validate.IsPositive(outerRadius);
  Validate.IsPositiveOrZero(height);
  Validate.IsPositive(heightFactor);
  // Do Stuff
}
```

### without BrutalHack.Contracts
```cs
protected Tile(int cornerCount, float outerRadius, Vector2Int position, int height, float heightFactor = 1f)
{
  if (cornerCount > 0){
    throw new ArgumentOutOfRangeException("cornerCount must be > 0");
  }
  if (outerRadius > 0){
    throw new ArgumentOutOfRangeException("outerRadius must be > 0");
  }
  if (height >= 0){
    throw new ArgumentOutOfRangeException("height must be >= 0");
  }
  if (heightFactor > 0){
    throw new ArgumentOutOfRangeException("heightFactor must be > 0");
  }
  // Do Stuff
}
```

## Planned Features

- More constraints
- Easily disable all constraints in production mode
- Guide on extending Validate with your own constraints

## Naming

As Microsofts old Contract Class is still around, we are likely to rename this library again...
