# filepath: speech-to-text.py
import streamlit as st
from azure.cognitiveservices.speech import SpeechConfig, SpeechRecognizer, AudioConfig, ResultReason

# Konfigurasi Azure
azure_key = st.secrets["azure"]["key"]
azure_region = st.secrets["azure"]["region"]

# Judul aplikasi
st.title("🎙️ Azure Speech-to-Text")
st.write("Aplikasi ini menggunakan Azure Speech-to-Text untuk mengubah audio menjadi teks.")

# Upload file audio
uploaded_file = st.file_uploader("Upload file audio (format .wav)", type=["wav"])

if uploaded_file is not None:
    # Simpan file audio sementara
    with open("temp_audio.wav", "wb") as f:
        f.write(uploaded_file.getbuffer())

    # Konfigurasi Azure Speech-to-Text
    speech_config = SpeechConfig(subscription=azure_key, region=azure_region)
    audio_config = AudioConfig(filename="temp_audio.wav")
    recognizer = SpeechRecognizer(speech_config=speech_config, audio_config=audio_config)

    st.write("⏳ Sedang memproses audio...")
    result = recognizer.recognize_once()

    # Tampilkan hasil
    if result.reason == ResultReason.RecognizedSpeech:
        st.success("✅ Teks yang dikenali:")
        st.write(result.text)
    else:
        st.error(f"❌ Gagal mengenali audio. Alasan: {result.reason}")