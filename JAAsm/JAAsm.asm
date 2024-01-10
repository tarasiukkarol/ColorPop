; rcx/xmm0 - piksele
; rdx/xmm1 - wybrany kolor
; r8/xmm2 - wsp�czynnik rgb
; r9/xmm3 - tabela z zakresem
; r11  - indeks startowy
; r10 - indeks ko�cowy

.CODE
ColorPop proc		
	mov			ebx, dword ptr[rbp + 48]	; Pobranie ze stosu warto�� indeksu startowego
	mov			r11, rbx					; Wpisanie jej do rejestru r11


	mov			ebx, dword ptr[rbp + 56]	; Pobranie ze stosu warto�� indeksu ko�cowego 
	mov			r10, rbx					; Wpisanie jej do rejestru r10


	movdqu		xmm1, oword ptr[rdx]		; Pobranie do xmm1 adresu pami�ci, gdzie przechowuje si�
											; dane o rozmiarze 8 bajt�w (octalword - 8)
											; z rejestru rdx - wybrany kolor

	movdqu		xmm2, oword ptr[r8]			; jw wsp�czynniki rgb
	movdqu		xmm3, oword ptr[r9]			; jw tablica warto�ci 255


	sub			r10, r11					; Odejmujemy indkeks startowy od ko�cowego
	mov			rdi, r10					; Wpisujemy do rdi
	shr			edi, 2						; Przesuwamy o 2 bity w prawo


	mov			rax, 4h						; do rejestru rax wpisujemy warto�� 4 (hex)
	mul			r11							; mno�ymy warto�� indeksu pocz�tkowego przez rejestr rax (pixel ma 4 warto�ci bgra)
	add			rcx, rax					; dodajemy otrzyman� warto�� do adresu tablicy wynikowej
											; rejestr rcx wskazuje w tablicy wynikowej pozycj� odpowiadaj�c� pierwszemu pikselowi,
											; kt�ry jest aktualnie przetwarzany

colorLoop:
	cmp			edi, 0h				 ; licznik p�tli
	je			endLoop				 ; skok do ko�ca p�tli
	
	movdqu		xmm0, oword ptr[rcx] ; pobieram do xmm0 warto�� piksela wskazywanego przez rejestr rcx

    movdqu      xmm5, xmm0           ; Kopiowanie xmm0 (RGB pixela) do xmm5
    movdqu      xmm6, xmm1			 ; Kopiowanie xmm1 (wybranego RGB) do xmm6
	
	subps		xmm5, xmm6			 ; Odejmujemy wybran� warto�� od pixela z bitmapy
	cmpps       xmm5, xmm3, 1        ; Por�wnujemy piksele xmm5 z xmm3 (zakresem) 
	movmskps	eax, xmm5			 ; Przenosimy do eax
	cmp			eax, 0				 ; Sprawdzamy czy znajduje si� w zakresie
    jpe         same_pixel           ; Skok, je�li warto�� jest w zakresie

    jmp			other_pixel 
other_pixel:

	movdqu		oword ptr[rcx], xmm0 ; orginalny piksel wpisujemy w odpowiednie miejsce w tablicy pikseli
	jmp skip

same_pixel:
	mulps		xmm0, xmm2			 ; mno�enie warto�ci piksela przez wsp�czynnik rgb
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
	add			rcx, 16				 ; przesuwamy wska�nik na kolejny piksel
	sub			rdi, 1				 ; dekrementujemy licznik p�tli
	jmp			colorLoop			 ; skok do pocz�tku p�tli
endLoop:
    ret
ColorPop endp
end