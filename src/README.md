0. init/pull/update submodule, then checkout target version tag
```bash
cd <this-dir>/godot
git pull
git checkout <target-version-tag>
```
1. config and run these commands
> https://docs.godotengine.org/en/stable/contributing/development/compiling/compiling_with_dotnet.html

```bash
godot-mono --headless --generate-mono-glue modules/mono/glue

./modules/mono/build_scripts/build_assemblies.py --godot-output-dir=./bin
```

2. after done, you will get `godot/bin/GodotSharp/Api/Release/*`
```bash
ls godot/bin/GodotSharp/Api/Release/*
```
