from PIL import Image
import cv2
import pytesseract

original_path = "Image1.png"
new_path_1 = "Crops/Image-Final1.png"
new_path_2 = "Crops/Image-Final2.png"
new_path_3 = "Crops/Image-Final3.png"

def create_readable_img():
    # Get original
    img = Image.open(original_path)

    # 1st crop
    area = (465, 390, 1550, 970)
    img = img.crop(area)

    # 2nd crop
    area = (0, 0, 170, 580)
    cropped_img1 = img.crop(area)


    # 3rd crop
    area = (680, 0, 1085, 580)
    cropped_img2 = img.crop(area)

    cropped_img1.save(new_path_2)
    cropped_img2.save(new_path_3)


def read_score(img_path):
    img = cv2.imread(img_path, cv2.IMREAD_GRAYSCALE)

    thresh = cv2.threshold(img, 100, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)[1]
    thresh = cv2.resize(thresh, (0, 0), fx=1.25, fy=1.25)  # scale image 1.25X

    return pytesseract.image_to_string(thresh, config='--psm 6')


create_readable_img()

all_player_names = read_score(new_path_2)
all_player_scores = read_score(new_path_3)

print(all_player_names)
print(all_player_scores)


