0. init and pull submodule
1. config and run these commands
> https://docs.godotengine.org/en/stable/contributing/development/compiling/compiling_with_dotnet.html

```bash
godot --headless --generate-mono-glue modules/mono/glue

./modules/mono/build_scripts/build_assemblies.py --godot-output-dir=./bin
```

after done, you will get `godot/bin/GodotSharp/Api/Release/*`
