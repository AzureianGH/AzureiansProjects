[BITS 16]
[ORG 0x7C00]

section .text
    mov ah, 0x06       ; Set AH to 0x06 for scroll function
    mov al, 0          ; Clear entire screen
    mov bh, 0x07       ; Display page (usually 0x07)
    mov ch, 0          ; Upper-left row (start)
    mov cl, 0          ; Upper-left column (start)
    mov dh, 24         ; Lower-right row (end)
    mov dl, 79         ; Lower-right column (end)
    int 0x10           ; Call BIOS interrupt to scroll

    mov ah, 0x0E       ; Set up AH for teletype output

    ; Loop to print "Hello"
    mov ecx, 5         ; Set the loop count to 5 (for "Hello")
    mov esi, helloText ; Load the address of the helloText string

printLoop:
    lodsb              ; Load the next character from helloText into AL
    cmp al, 0          ; Check if it's the null terminator
    je endPrint        ; If it is, end the loop
    int 0x10           ; Call BIOS interrupt to print
    loop printLoop     ; Repeat the loop

endPrint:
    jmp $              ; Infinite loop

helloText db "\nHello", 0

times 510 - ($ - $$) db 0
dw 0xAA55
