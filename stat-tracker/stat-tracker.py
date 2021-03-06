from PIL import Image
import cv2
import pytesseract
import os

pytesseract.pytesseract.tesseract_cmd = r'C:\Program Files\Tesseract-OCR\tesseract.exe'

current_path = os.path.dirname(__file__)
original_path = os.sys.argv[1]
# original_path = r"C:\Users\Stef Robbe\Documents\GitHub projects\Personal\R6-Stat-Tracker\stat-tracker\Image4.png"

path_to_names = current_path + "/Crops/names.png"
path_to_scores = current_path + "/Crops/scores.png"

def create_readable_img():
    img = Image.open(original_path)

    # 1st crop
    area = (463, 390, 720, 960)
    names = img.crop(area)

    # 2nd crop
    area = (1150, 400, 1540, 970)
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
    scores = scores.splitlines()

    all_scores = []
    score = []
    first = True

    for x, b in enumerate(scores):
        if x != 0:
            b = b.split()
            if len(b) == 12:
                if len(str(b[11])) > 2 and first == False or x == len(scores) - 1:
                    if x == len(scores) - 1:
                        score.append(str(b[11]))
                    all_scores.append(score)
                    score = []
                score.append(str(b[11]))
                first = False

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

def print_names_scores():
    for score in scores_final:
        for s in score:
            print(s)
            


create_readable_img()

all_player_names = tesseract_read(path_to_names)
all_player_scores = tesseract_read(path_to_scores)

names = get_names(all_player_names)
scores = get_scores(all_player_scores)

scores_final = combine_names_scores()

print_names_scores()
