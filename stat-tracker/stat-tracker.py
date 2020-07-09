import cv2
import pytesseract
import numpy as np


pytesseract.pytesseract.tesseract_cmd = 'C:\\Program Files (x86)\\Tesseract-OCR\\tesseract.exe'
img = cv2.imread('Images/Image4.png', cv2.IMREAD_GRAYSCALE)
# tozero
_, th1 = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY_INV)

values = []
data = pytesseract.image_to_data(img)
for x, d in enumerate(data.splitlines()):
    if x != 0:
        d = d.split()
        if len(d) == 12:
            values.append(d[11])


print(values)
cv2.imshow('th1', th1)
cv2.imshow('img', img)

cv2.waitKey(0)
cv2.destroyAllWindows()
