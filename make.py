from subprocess import run
from zipfile import ZipFile

BUILD_COMMAND =  'msbuild ./BonkHitSfxFixed.sln  -t:Rebuild -p:Configuration=Release'


run(BUILD_COMMAND, shell=True, check=True)

with ZipFile('BonkHitSfxFixed.zip', 'w') as zipObj:
    zipObj.write('./bin/Release/BonkHitSfxFixed.dll', 'BonkHitSfxFixed.dll')
    zipObj.write('./bonkhitsfxfixed', 'bonkhitsfxfixed')
    zipObj.write('./icon.png', 'icon.png')
    zipObj.write('./README.md', 'README.md')
    zipObj.write('./manifest.json', 'manifest.json')
