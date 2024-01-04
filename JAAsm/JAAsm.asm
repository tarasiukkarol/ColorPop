.code 
ColorPop proc
	mov			ebx, dword ptr[rbp + 40]	; Pobieramy ze stosu warto�� indeksu startowego
	mov			r11, rbx					; Wpisujemy j� do rejestru r11


	mov			ebx, dword ptr[rbp + 48]	; To samo robimy z warto�ci� indeksu ko�cowego 
	mov			r10, rbx					; Wpisujemy j� do rejestru r10


	;movdqu		xmm1, oword ptr[rdx]		; pobieramy do xmm1 adres pami�ci, gdzie przechowuje si�
											; dane o rozmiarze 8 bajt�w (octalword - 8) - w tym przypadku
											; z rejestru rdx --- wybrany kolor

	movdqu		xmm2, oword ptr[r8]			; analogicznie --- wsp�czynniki rgb
	;movdqu		xmm3, oword ptr[r9]			; analogicznie --- tablica warto�ci 255


	sub			r10, r11					; Odejmujemy indkeks startowy od ko�cowego
	mov			rdi, r10					; Wpisujemy do rdi
	shr			edi, 2						; Dzielimy wynik przez 4, bo ka�dy piksel to 4 warto�ci - bgra
											; Przesuwamy o 2 bity w prawo


	mov			rax, 4h						; do rejestru rax wpisujemy warto�� 4 w zapisie hex
	mul			r11							; mno�ymy warto�� indeksu pocz�tkowego przez rejestr  rax (czyli 4 - bo piksel to 4 warto�ci bgra)
	add			rcx, rax					; dodajemy otrzyman� warto�� do adresu tablicy wynikowej
											; dzi�ki temu rejestr rcx wskazuje w tablicy wynikowej pozycj� odpowiadaj�c� pierwszemu pikselowi
											; kawa�ka, kt�ry jest aktualnie przetwarzany


sepiaLoop:
	cmp			edi, 0h						; je�li licznik p�tli dojdzie do 0 - wychodzimy
	je			endLoop						; skok do ko�ca p�tli
	
	movdqu		xmm0, oword ptr[rcx]		; pobieramy do xmm0 warto�� piksela wskazywanego przez rejestr rcx

	mulps		xmm0, xmm2					; mno�ymy warto�ci opisuj�ce pobrany piksel przez odpowiednie wsp�czynniki
	


											; w xmm0 mamy (a | r | g | b)
	movshdup    xmm4, xmm0					; w rejestrze xmm4 otrzymujemy (a | a | g | g)
    addps       xmm0, xmm4					; w xmm0 otrzymujemy (a+a | r+a | g+g | b+g)
    movhlps     xmm4, xmm0					; w xmm4 otrzymujemy (a | a | a+a | r+a)
    addps       xmm0, xmm4					; w xmm0 otrzymujemy (a+a+a | r+a+a | g+g+a+a | a+r+g+b)
	punpckldq	xmm0, xmm0					; w xmm0 otrzymujemy (g+g+a+a | g+g+a+a | a+r+g+b | a+r+g+b)
	punpcklqdq	xmm0, xmm0					; w xmm0 otrzymujemy (a+r+g+b | a+r+g+b | a+r+g+b | a+r+g+b)

	;addps		xmm0, xmm1					; dodajemy odpowiednie wsp�czynniki rgb do odpowienich warto�ci piksela

	;minps		xmm0, xmm3					; kolejne warto�ci piksela por�wnujemy z warto�ciami 255 i wybieramy mniejsze
	movdqu		oword ptr[rcx], xmm0		; przetworzony piksel wpisujemy w odpowiednie miejsce w tablicy pikseli
	
	add			rcx, 16						; przesuwamy wska�nik na kolejny piksel
	sub			rdi, 1						; dekrementujemy licznik p�tli
	jmp			sepiaLoop					; skok do pocz�tku p�tli
endLoop:
    ret
ColorPop endp 
end