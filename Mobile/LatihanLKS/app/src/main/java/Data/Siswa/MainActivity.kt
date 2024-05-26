package Data.Siswa

import Data.Siswa.databinding.ActivityMainBinding
import Data.Siswa.databinding.HalamanUtamaBinding
import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        var binding = ActivityMainBinding.inflate(this.layoutInflater)
        setContentView(binding.root)



        binding.buttonAdd.setOnClickListener{
            startActivity(Intent(this@MainActivity, MainActivity3::class.java))
        }

        GlobalScope.launch (Dispatchers.IO) {
            try{
                
                var usser =
                    URL("https://65dd3fc8e7edadead7ed9083.mockapi.io/DataSisw/LatihanAPI").openStream()
                        .bufferedReader().readText()
                var ussr = JSONArray(usser)

                runOnUiThread {


                    var adapter = object : RecyclerView.Adapter<kofiViewholder>() {
                            override fun onCreateViewHolder(
                                parent: ViewGroup,
                                viewType: Int
                            ): kofiViewholder {
                                var binding = HalamanUtamaBinding.inflate(
                                    LayoutInflater.from(parent.context),
                                    parent,
                                    false
                                )
                                return kofiViewholder(binding)
                            }


                        override fun getItemCount(): Int = ussr.length()
                        override fun onBindViewHolder(holder: kofiViewholder, position: Int) {
                            val user = ussr.getJSONObject(position)
                            holder.binding.nis.text = user.getString("Nis")
                            holder.binding.namaku.text = user.getString("Nama")
                            holder.binding.tanggal.text = user.getString("Tanggal")
                            holder.binding.jenis.text = user.getString("JenisKelamin")
                            holder.binding.root.setOnClickListener {
                                val inten = Intent(this@MainActivity, MainActivity2::class.java)
                                inten.putExtra("detail", user.toString())
                                startActivity(inten)
                            }
                            holder.binding.card.setOnClickListener {



                                startActivity(Intent(this@MainActivity, MainActivity2::class.java).putExtra("id",user.getString("id")))
                            }

                        }

                    }

                    binding.nama.adapter = adapter
                    binding.nama.layoutManager = LinearLayoutManager(this@MainActivity)






                }
            }
            catch (e:Exception){

            }
        }
    }      class kofiViewholder(val binding: HalamanUtamaBinding ): RecyclerView.ViewHolder(binding.root)
}
