Write-Host 'Packing the nuget package.'

pushd CompulsoryCow

.\..\nuget.exe pack -Prop Configuration=Release

popd
