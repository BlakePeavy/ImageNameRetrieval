# ImageNameRetrieval User Documentation

## Overview
**ImageNameRetrieval** is a console-based application that retrieves image names from the Pexels API based on a user-defined search query and specified number of results.

## Table of Contents
1. [Getting Started](#getting-started)
2. [Installation](#installation)
3. [Configuration](#configuration)
4. [Usage](#usage)
5. [FAQ](#faq)

## 1. Getting Started

**ImageNameRetrieval** allows you to quickly retrieve image information from Pexels based on a keyword search.

---

## 2. Installation

### Prerequisites
- **Windows** operating system (self-contained executable built for Windows).

### Installation Steps

1. **Download the package**:
   - Go to [Releases](https://github.com/BlakePeavy/ImageNameRetrieval/releases/tag/1.0.0.0) and download the current package.

2. **Extract the package**:
   - Right click the downloaded ZIP file and select **Extract All**.

3. **Run the Application**:
   - Open the extracted folder.
   - Open 'ImageNameRetrieval.App.exe' to launch the application.

---

## 3. Configuration

The application requires a **Pexels API key** to access image data from the Pexels API. Follow these steps to configure it:

### Obtain a Pexels API Key

1. Go to [Pexels Developer](https://www.pexels.com/api/) and sign up for an account if you don’t have one.
2. Navigate to the **API Documentation** page and generate an API key.

---

## 4. Usage
Once the application is running, it will prompt you to input a search query, the number of images to retrieve, and the API key.

### Example Usage
1. **Start the Application**:
   - Run `ImageNameRetrieval.exe`.

2. **Enter Pexels API Key**:
   - Input Pexels API Key obtained during configuration.

3. **Enter a Search Query**:
   - Input a keyword for image search (e.g., `birds`, `planets`).
   - Only letters and numbers are accepted (e.g., `planets` is valid, `pl@nets` is invalid).

4. **Specify Number of Results**:
   - Enter the maximum number of images to retrieve (between 1 and 25).
   - The app will output the `alt` text (description) for each image found in the search results.

### Sample Interaction
```
Please input a API Key for Pexel: API_KEY
Image Search Query: nature
Maximum search display (1-25): 5
Planet Earth
Earth Wallpaper
Blue and White Planet Display
Eye of the Storm Image from Outer Space
Round Brown and Black Ornament
```
---

## 5. FAQ

#### Q: Can I retrieve more than 25 images at once?
   **A**: Currently, the maximum allowed is 25.

---

