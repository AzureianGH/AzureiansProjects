nasm -f bin kernel.asm -o kernel.bin
qemu-system-i386 -hda kernel.bin
pause