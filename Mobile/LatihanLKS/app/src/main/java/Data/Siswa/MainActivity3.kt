package Data.Siswa

import Data.Siswa.databinding.ActivityMain3Binding
import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import org.json.JSONObject
import java.io.DataOutputStream
import java.net.HttpURLConnection
import java.net.URL

class MainActivity3 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        var binding = ActivityMain3Binding.inflate(this.layoutInflater)
        setContentView(binding.root)

        // add crud add in android
        binding.masuk.setOnClickListener {

            GlobalScope.launch(Dispatchers.IO) {
//                val connKota = URL("https://65dd3fc8e7edadead7ed9083.mockapi.io/DataSisw/LatihanAPI").openStream()
//                    .bufferedReader().readText()
//                val dataKota = JSONArray(connKota)
                val conn = URL(
                    "https://65dd3fc8e7edadead7ed9083.mockapi.io/DataSisw/LatihanAPI"
                ).openConnection() as HttpURLConnection
                conn.requestMethod = "POST"
                conn.setRequestProperty("Content-Type", "application/json")
                var sex = "non"
                if (binding.eLaki.isChecked) sex = "laki "
                else if (binding.ePerempuan.isChecked) sex = "perempuan"
                var json = JSONObject().apply {
                    put("Nis", binding.nis.text)
                    put("Nama", binding.nama.text)
                    put("kotaId", 1)
                    put("Tanggal", binding.tanggal.text)
                    put("JenisKelamin", sex)
                    put("alamat", binding.alamat.text)
                }

                conn.outputStream.write(json.toString().toByteArray())
                var code = conn.responseCode
                if (code == 200 or 201) {

                    startActivity(Intent(this@MainActivity3, MainActivity::class.java))
                } else {
                    val error = JSONObject(conn.errorStream.bufferedReader().readText())
                    runOnUiThread {

                        Toast.makeText(
                            this@MainActivity3,
                            "Error because ${error.getString("message")}",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }

                conn.outputStream.write(json.toString().toByteArray())

                startActivity(Intent(this@MainActivity3, MainActivity::class.java))


            }


        }   }
}
