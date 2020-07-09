import cv2
import pytesseract


def read_img():
    pytesseract.pytesseract.tesseract_cmd = 'C:\\Program Files (x86)\\Tesseract-OCR\\tesseract.exe'
    img = cv2.imread('Images/Image4.png', cv2.IMREAD_GRAYSCALE)
    # tozero
    _, th1 = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY)
    return th1, img


def process_text(img):
    values = []
    data = pytesseract.image_to_data(img)
    for x, d in enumerate(data.splitlines()):
        if x != 0:
            d = d.split()
            if len(d) == 12:
                values.append(d[11])

    return values


th1, img = read_img()
print(process_text(th1))
cv2.imshow('th1', th1)
cv2.imshow('img', img)

cv2.waitKey(0)
cv2.destroyAllWindows()
