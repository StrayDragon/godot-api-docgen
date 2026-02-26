先把终端切到这个 README 所在目录，然后整段执行下面命令即可。

参考文档：
https://docs.godotengine.org/en/stable/contributing/development/compiling/compiling_with_dotnet.html

```bash
# 需要其他版本就改这里

# git submodule update --init --recursive # 确保顶层完成 submodule 初始化
cd godot
git pull
TARGET_TAG=4.6.1-stable git checkout "$TARGET_TAG"

cd ..
godot-mono --headless --generate-mono-glue godot/modules/mono/glue
./godot/modules/mono/build_scripts/build_assemblies.py --godot-output-dir=./godot/bin

# 验证
ls godot/bin/GodotSharp/Api/Release/*
```
