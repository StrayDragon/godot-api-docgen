# What is this?

Unofficial Godot4 C# API documentation:
- **4.2.2-stable**: https://straydragon.github.io/godot-csharp-api-doc/4.2.2-stable/
> Separate into another repository which serves as a documentation repository., see https://github.com/StrayDragon/godot-csharp-api-doc
  

## How to build?

0. perpare target version *.dll metafiles. see [src/README.md](./src/README.md)
1. replace target version from old version in `docfx.json` like this
```bash
sed -i 's/4.2.2-stable/4.3-stable/g' docfx.json
```
2. `make build-doc`


# Related projects & Inspired by

- Godot4 GdScript & C# docs: https://github.com/nicholas-maltbie/gddoc2yml
- Godot3.5 C# api reference: https://github.com/paulloz/godot-csharp-api


# References

- [Godot Engine 4.2 documentation](https://docs.godotengine.org/en/stable/contributing/development/compiling/compiling_with_dotnet.html)
- [DocFx](https://github.com/dotnet/docfx)


# License

See [LICENSE](./LICENSE) and [index.md](./index.md) file for license details.
