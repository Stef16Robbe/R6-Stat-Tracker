import cv2
import pytesseract


# pytesseract.image_to_string(img, config='--psm 6')

def read_img():
    pytesseract.pytesseract.tesseract_cmd = 'C:\\Program Files (x86)\\Tesseract-OCR\\tesseract.exe'
    img = cv2.imread('Images/Image3-S.png')
    return cv2.cvtColor(img, cv2.COLOR_BGR2RGB)


def process_text(img):
    names = []
    data = pytesseract.image_to_data(img)
    for x, d in enumerate(data.splitlines()):
        if x != 0:
            d = d.split()
            if len(d) == 12:
                names.append(d[11])

    return names



def show_img(img):
    cv2.imshow('Result', img)
    cv2.waitKey(0)


img = read_img()
print(process_text(img))
show_img(img)


