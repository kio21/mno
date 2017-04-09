#!/bin/bash

echo "Clean all bin/obj folders"
echo "-------------------------"

echo "-== Go to src folder ==-"
cd ..

echo "-== Force clean solution ==-"
projects=(
    mno
)
for item in ${projects[*]}
do
    printf "   clean %s" $item
    rm -rfv "$item/bin"
    rm -rfv "$item/obj"
    printf " OK\n"
done
echo "-== Force clean solution - OK ==-"
