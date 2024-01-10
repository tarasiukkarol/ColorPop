; rcx/xmm0 - piksele
; rdx/xmm1 - wybrany kolor
; r8/xmm2 - wspó³czynnik rgb
; r9/xmm3 - tabela z zakresem
; r11  - indeks startowy
; r10 - indeks koñcowy

.CODE
ColorPop proc		
	mov			ebx, dword ptr[rbp + 48]	; Pobranie ze stosu wartoœæ indeksu startowego
	mov			r11, rbx					; Wpisanie jej do rejestru r11


	mov			ebx, dword ptr[rbp + 56]	; Pobranie ze stosu wartoœæ indeksu koñcowego 
	mov			r10, rbx					; Wpisanie jej do rejestru r10


	movdqu		xmm1, oword ptr[rdx]		; Pobranie do xmm1 adresu pamiêci, gdzie przechowuje siê
											; dane o rozmiarze 8 bajtów (octalword - 8)
											; z rejestru rdx - wybrany kolor

	movdqu		xmm2, oword ptr[r8]			; jw wspó³czynniki rgb
	movdqu		xmm3, oword ptr[r9]			; jw tablica wartoœci 255


	sub			r10, r11					; Odejmujemy indkeks startowy od koñcowego
	mov			rdi, r10					; Wpisujemy do rdi
	shr			edi, 2						; Przesuwamy o 2 bity w prawo


	mov			rax, 4h						; do rejestru rax wpisujemy wartoœæ 4 (hex)
	mul			r11							; mno¿ymy wartoœæ indeksu pocz¹tkowego przez rejestr rax (pixel ma 4 wartoœci bgra)
	add			rcx, rax					; dodajemy otrzyman¹ wartoœæ do adresu tablicy wynikowej
											; rejestr rcx wskazuje w tablicy wynikowej pozycjê odpowiadaj¹c¹ pierwszemu pikselowi,
											; który jest aktualnie przetwarzany

colorLoop:
	cmp			edi, 0h				 ; licznik pêtli
	je			endLoop				 ; skok do koñca pêtli
	
	movdqu		xmm0, oword ptr[rcx] ; pobieram do xmm0 wartoœæ piksela wskazywanego przez rejestr rcx

    movdqu      xmm5, xmm0           ; Kopiowanie xmm0 (RGB pixela) do xmm5
    movdqu      xmm6, xmm1			 ; Kopiowanie xmm1 (wybranego RGB) do xmm6
	
	subps		xmm5, xmm6			 ; Odejmujemy wybran¹ wartoœæ od pixela z bitmapy
	cmpps       xmm5, xmm3, 1        ; Porównujemy piksele xmm5 z xmm3 (zakresem) 
	movmskps	eax, xmm5			 ; Przenosimy do eax
	cmp			eax, 0				 ; Sprawdzamy czy znajduje siê w zakresie
    jpe         same_pixel           ; Skok, jeœli wartoœæ jest w zakresie

    jmp			other_pixel 
other_pixel:

	movdqu		oword ptr[rcx], xmm0 ; orginalny piksel wpisujemy w odpowiednie miejsce w tablicy pikseli
	jmp skip

same_pixel:
	mulps		xmm0, xmm2			 ; mno¿enie wartoœci piksela przez wspó³czynnik rgb
									 ; w xmm0 mamy (a | r | g | b)
	movshdup    xmm4, xmm0			 ; w rejestrze xmm4 otrzymujemy (a | a | g | g)
    addps       xmm0, xmm4			 ; w xmm0 otrzymujemy (a+a | r+a | g+g | b+g)
    movhlps     xmm4, xmm0			 ; w xmm4 otrzymujemy (a | a | a+a | r+a)
    addps       xmm0, xmm4			 ; w xmm0 otrzymujemy (a+a+a | r+a+a | g+g+a+a | a+r+g+b)
	punpckldq	xmm0, xmm0			 ; w xmm0 otrzymujemy (g+g+a+a | g+g+a+a | a+r+g+b | a+r+g+b)
	punpcklqdq	xmm0, xmm0			 ; w xmm0 otrzymujemy (a+r+g+b | a+r+g+b | a+r+g+b | a+r+g+b)
	movdqu		oword ptr[rcx], xmm0 ; przetworzony piksel wpisujemy w odpowiednie miejsce w tablicy pikseli
	jmp         skip
	
skip:
	add			rcx, 16				 ; przesuwamy wskaŸnik na kolejny piksel
	sub			rdi, 1				 ; dekrementujemy licznik pêtli
	jmp			colorLoop			 ; skok do pocz¹tku pêtli
endLoop:
    ret
ColorPop endp
end