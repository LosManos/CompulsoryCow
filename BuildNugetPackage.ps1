Write-Host 'Packing the nuget package.'

Write-Host 'Make sure the solution has been built as Relase first.'
Write-Host 'Do not forget to update assemblyinfo with the version number.'
Write-Host 'Do not forget to update readme with version number.'
Read-Host 'Press return when ready'

pushd CompulsoryCow

.\..\nuget.exe pack -Prop Configuration=Release

popd
