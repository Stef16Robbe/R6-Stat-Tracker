import cv2

# img[w - 10: w + 10, h - 10: h + 10] = [255, 255, 255]

img = cv2.imread('Image4.png')
height, width = img.shape[:2]

white_pixel = []

# loop through all pixels in image
for h in range(height):
    for w in range(width):
        # if pixel is white, add it to white_pixel list ...
        continue

for p in white_pixel:
    # change color of pixel to see if it worked ...
    continue


cv2.imshow('Result', img)
cv2.waitKey(0)
