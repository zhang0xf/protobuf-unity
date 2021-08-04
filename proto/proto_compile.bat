set PROTO_DIR=./proto
set CPP_OUT=../protobuf-unity/Assets/Scripts/Protobuf

protoc.exe -I=%PROTO_DIR% --csharp_out=%CPP_OUT% %PROTO_DIR%/addressbook.proto

pause
 