from PIL import Image
import cv2
import pytesseract

original_path = "Image1.png"
path_to_names = "Crops/names.png"
path_to_scores = "Crops/scores.png"

def create_readable_img():
    img = Image.open(original_path)

    # 1st crop
    area = (465, 390, 1550, 970)
    img = img.crop(area)

    # 2nd crop
    area = (0, 0, 170, 580)
    names = img.crop(area)

    # 3rd crop
    area = (680, 0, 1085, 580)
    scores = img.crop(area)

    names.save(path_to_names)
    scores.save(path_to_scores)


def tesseract_read(img_path):
    img = cv2.imread(img_path, cv2.IMREAD_GRAYSCALE)

    thresh = cv2.threshold(img, 100, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)[1]
    thresh = cv2.resize(thresh, (0, 0), fx=1.25, fy=1.25)  # scale image 1.25X

    return pytesseract.image_to_data(thresh, config='--psm 6')

def get_names(names):
    all_names = []
    for x, b in enumerate(names.splitlines()):
        if x != 0:
            b = b.split()
            if len(b) == 12:
                all_names.append(b[11])

    return all_names

def get_scores(scores):
    all_scores = []
    score = []
    i = 0
    for x, b in enumerate(scores.splitlines()):
        if x != 0:
            b = b.split()
            if len(b) == 12:
                if i == 4:
                    all_scores.append(score)
                    score = []
                    i = 0
                score.append(str(b[11]))
                i += 1

    return all_scores

def combine_names_scores():
    i = 0
    sc = []
    scores_final = []
    for score in scores:
        sc.append(names[i])
        for s in score:
            sc.append(s)
        scores_final.append(sc)
        sc = []
        i += 1

    return scores_final


create_readable_img()

all_player_names = tesseract_read(path_to_names)
all_player_scores = tesseract_read(path_to_scores)

names = get_names(all_player_names)
scores = get_scores(all_player_scores)

print(combine_names_scores())
