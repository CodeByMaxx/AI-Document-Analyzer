import { useState } from "react";
import { uploadDocument } from "../api/documentApi";


function UploadPage() {

    const [file, setFile] = useState<File | null>(null);
    const [message, setMessage] = useState("");

    async function handleUpload() {

        if (!file) {
            setMessage("Bitte eine PDF auswählen.");
            return;
        }

        try {

            const result = await uploadDocument(file);

            setMessage(
                `${result.fileName} erfolgreich hochgeladen`
            );

        } catch (error) {

            setMessage("Upload fehlgeschlagen");

        }
    }


    return (
        <div>

            <h1>
                AI Document Analyzer
            </h1>


            <input
                type="file"
                accept=".pdf"
                onChange={(e) =>
                    setFile(e.target.files?.[0] ?? null)
                }
            />


            <button onClick={handleUpload}>
                Upload
            </button>


            <p>
                {message}
            </p>

        </div>
    );
}


export default UploadPage;
