import os

try:

    method = 0
    opt = 0
    originaltext=""
    arr=[]

    print("Press 1 for Encrypt\nPress 2 for Decrypt\n\n")
    o = int(input(""))

    os.system('cls')


    print("Choose ROT 1 to 25\n pick a number")
    option = int(input(""))

    os.system('cls')


    if (option >= 1 and option <= 25):
        opt=option
        method=o

    else:
        print("Please choose number between 1 to 25")



    usr = ""
    print("Enter your text")
    usr = input("")
    usr = usr.lower()


    text=usr

    for i in range(len(text)):
        arr.append(ord(text[i]))

    
    if method == 1:
        for i in range(len(arr)):
            if arr[i] >= 65 and arr[i] <= 90 or arr[i] >= 97 and arr[i] <= 122:
                if arr[i] - opt == arr[i] - opt and arr[i] <= 122 - opt:
                    arr[i] += opt
                        
                elif arr[i] >= 90 and arr[i] <= 122:
                    arr[i] -= 26
                    arr[i] += opt
                        
    elif method == 2:
        for i in range(len(arr)):
            if arr[i] >= 65 and arr[i] <= 90 or arr[i] >= 97 and arr[i] <= 122:
                if arr[i] + opt == arr[i] + opt and arr[i] > 122 - opt:
                    arr[i] -= opt
                        
                elif arr[i] >= 90 and arr[i] <= 122:
                    arr[i] += 26
                    arr[i] -= opt
    
    os.system('cls')
    
    print("Orginal text (Input)\n\n")
    print(usr + "\n\n\n")
    print("________________________________________________________________________________\n\n")

    # // Output
    print("Result (Output)\n\n")
    for i in range(len(arr)):
        print(chr(arr[i]),end="")
    print("\n\n\n\n")
        
        


except:
    print("Wrong input handling")




