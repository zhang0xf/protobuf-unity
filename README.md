# protobuf-unity

Unity demo with protobuf

## Version

* protoc-3.17.3-win32.zip
* protobuf-csharp-3.17.3.tar.gz

## Build `DLL` for unity on WIN

* download source `protobuf-csharp-3.17.3.tar.gz`
* use visual studio open `\protobuf-3.17.3\csharp\src\Google.Protobuf.sln`
* set Google.Protobuf as default and build `DLL`
![image_text](https://github.com/zhang0xf/protobuf-unity/blob/main/image/choose_google_protobuf_as_default.png)
![image_text](https://github.com/zhang0xf/protobuf-unity/blob/main/image/compile_dll.PNG)
* all files in `\protobuf-3.17.3\csharp\src\Google.Protobuf\bin\Release\net45` are needed, copy them to `Assets/Plugins`.
![image_text](https://github.com/zhang0xf/protobuf-unity/blob/main/image/files_neededby_unity.PNG)

## Use protoc to compile .proto files

* download release `protoc-3.17.3-win32.zip`
* "protoc.exe" and "include" should be in same level directory. beacuse we gona `import "google/protobuf/timestamp.proto";`
* run `proto_compile.bat` and generate `.cs` files

# Reference

[Unity C# 编译集成 Google Protobuf](https://john.js.org/2020/11/17/CSharp-Compile-With-Google-Protobuf/)

[Protocol Buffer Basics: C#](https://developers.google.com/protocol-buffers/docs/csharptutorial)

[addressbook.proto](https://github.com/protocolbuffers/protobuf/blob/master/examples/addressbook.proto)

[Protocol Buffers v3.17.3](https://github.com/protocolbuffers/protobuf/releases/tag/v3.17.3)

[C# Generated Code](https://developers.google.com/protocol-buffers/docs/reference/csharp-generated)

[C# README.md](https://github.com/protocolbuffers/protobuf/tree/master/csharp)
