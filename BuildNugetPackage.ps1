Write-Host 'Packing the nuget package.'

Write-Host 'If you haven''t in compile to Release, do that now.'
Read-Host 'Press enter to continue.';

pushd CompulsoryCow

.\..\nuget.exe pack -Prop Configuration=Release

popd
