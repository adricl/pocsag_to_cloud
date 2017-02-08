#!/bin/bash
rtl_fm -A fast -f 148.637M -M fm -s 22050 -g 44.5 -l 305 | multimon-ng -t raw -a POCSAG512 -a POCSAG1200 -a POCSAG2400 -f alpha /dev/stdin | dotnet run config.json
