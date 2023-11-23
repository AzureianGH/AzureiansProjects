.model small

.data
  msg db "Hello World!$"
  msglen equ $ - msg ; $ is the current address

.code
main:
  mov ah, 40h       ; AH = 40h for sys_write
  mov bx, 1         ; BX = 1 for file descriptor stdout
  mov cx, msg       ; CX = pointer to the message
  mov dx, msglen    ; DX = length of the message
  int 21h           ; Invoke DOS syscall (assuming you are using DOS interrupts)

  mov ah, 4Ch       ; AH = 4Ch for sys_exit
  int 21h           ; Invoke DOS syscall for program termination
end main
