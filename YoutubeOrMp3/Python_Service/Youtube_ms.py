from flask import Flask, request, jsonify
import subprocess
import os

app = Flask(__name__)

DOWNLOAD_DIR = "C:\\Users\\lifep\\Desktop\\archive"

if not os.path.exists(DOWNLOAD_DIR):
    os.makedirs(DOWNLOAD_DIR)

@app.route('/download', methods=['POST'])
def download():
    data = request.get_json()
    url = data.get('url')
    
    if not url:
        return jsonify({"message": "URL is missing"}), 400

    try:
        result = subprocess.run(
            ['youtube-dl', '--extract-audio', '--audio-format', 'mp3', '-o', f'{DOWNLOAD_DIR}/%(title)s.%(ext)s', url],
            check=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE
        )
        return jsonify({"message": "Download successful", "output": result.stdout.decode('utf-8')})
    except subprocess.CalledProcessError as e:
        return jsonify({"message": "Error during download", "output": e.stderr.decode('utf-8')}), 500

if __name__ == '__main__':
    app.run(debug=True)
