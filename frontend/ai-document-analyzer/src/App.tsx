import UploadPage from "./pages/UploadPage";
import { useState } from "react";
import axios from "axios";

interface DocumentResult {
  id: string;
  fileName: string;
  fileSize: number;
  uploadedAt: string;
  status: string;
  extractedText: string;
}

function App() {
  const [file, setFile] = useState<File | null>(null);
  const [result, setResult] = useState<DocumentResult | null>(null);
  const [error, setError] = useState<string>("");
  const [loading, setLoading] = useState(false);


  const uploadFile = async () => {
    if (!file) {
      setError("Bitte zuerst eine PDF auswählen.");
      return;
    }

    setError("");
    setResult(null);
    setLoading(true);

    const formData = new FormData();
    formData.append("file", file);


    try {
      const response = await axios.post<DocumentResult>(
        "http://localhost:5271/api/Documents/upload",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );

      setResult(response.data);
    } 
    catch (err) {
      console.error(err);
      setError(
        "Upload fehlgeschlagen. Prüfe ob das Backend läuft."
      );
    } 
    finally {
      setLoading(false);
    }
  };


  return (
    <div className="container">

      <h1>
        AI Document Analyzer
      </h1>


      <div className="upload-box">

        <input
          type="file"
          accept=".pdf"
          onChange={(event) => {
            const selectedFile =
              event.target.files?.[0];

            setFile(selectedFile ?? null);
          }}
        />


        <button
          onClick={uploadFile}
          disabled={loading}
        >
          {loading
            ? "Analysiere..."
            : "PDF hochladen"}
        </button>

      </div>


      {error && (
        <div className="error">
          {error}
        </div>
      )}



      {result && (
        <div className="result">

          <h2>
            Analyse Ergebnis
          </h2>


          <p>
            <strong>Datei:</strong>{" "}
            {result.fileName}
          </p>


          <p>
            <strong>Größe:</strong>{" "}
            {result.fileSize} Bytes
          </p>


          <p>
            <strong>Status:</strong>{" "}
            {result.status}
          </p>


          <p>
            <strong>Upload:</strong>{" "}
            {new Date(result.uploadedAt).toLocaleString()}
          </p>


          <h3>
            Extrahierter Text
          </h3>


          <pre>
            {result.extractedText}
          </pre>

          <pre
            style={{
            whiteSpace: "pre-wrap",
            background: "#f5f5f5",
            padding: "1rem",
            borderRadius: "8px"
            }}
            >
            {result.aiAnalysis}
          </pre>
        </div>
      )}

    </div>
  );
}

export default App;

