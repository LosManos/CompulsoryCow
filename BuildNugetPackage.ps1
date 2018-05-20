Write-Host 'Packing the nuget package.'

Write-Host 'Make sure the solution has been built as Relase first.'
Read-Host 'Press return when ready'

pushd CompulsoryCow

.\..\nuget.exe pack -Prop Configuration=Release

popd
