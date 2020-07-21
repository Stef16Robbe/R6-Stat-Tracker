import cv2
import pytesseract


def read_score():
    img = cv2.imread('Images/Image5.png', cv2.IMREAD_GRAYSCALE)

    thresh = cv2.threshold(img, 100, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)[1]
    thresh = cv2.resize(thresh, (0, 0), fx=1.25, fy=1.25)  # scale image 1.25X

    return pytesseract.image_to_string(thresh, config='--psm 6')


scores = read_score()
