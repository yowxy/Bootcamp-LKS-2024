package Data.Siswa

import Data.Siswa.databinding.ActivityMain2Binding
import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.URL

class MainActivity2 : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        var binding = ActivityMain2Binding.inflate(this.layoutInflater)
        setContentView(binding.root )

        val id = intent.getStringExtra("id")
        GlobalScope.launch(Dispatchers.IO) {

        var url = URL ("https://65dd3fc8e7edadead7ed9083.mockapi.io/DataSisw/LatihanAPI/$id")


        GlobalScope.launch (Dispatchers.IO){

            val conn = URL("https://65dd3fc8e7edadead7ed9083.mockapi.io/DataSisw/LatihanAPI/$id").openStream().bufferedReader().readText()
            val jsonn = JSONObject(conn)



            GlobalScope.launch (Dispatchers.Main){

                binding.namauser.text = jsonn.getString("Nama")
                binding.nama2.text = jsonn.getString("Tanggal")
                binding.namaa3.text = jsonn.getString("JenisKelamin")




            }

        }




        }



        
        
        

        }
    }

