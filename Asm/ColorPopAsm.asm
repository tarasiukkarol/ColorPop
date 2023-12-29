.code 
MyProc1 proc
movdqu xmm0, [rcx]

mulps xmm0, xmm1

ret 
MyProc1 endp 
end