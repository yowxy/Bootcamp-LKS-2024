package com.example.esemkapetitionv2

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.MenuItem
import android.view.ViewGroup
import android.widget.LinearLayout
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.drawerlayout.widget.DrawerLayout
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.esemkapetitionv2.databinding.ActivityMainscreenBinding
import com.example.esemkapetitionv2.databinding.CardpetitionBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONArray
import java.net.URL
import kotlin.math.log

class Mainscreen : AppCompatActivity() {
    lateinit var binding: ActivityMainscreenBinding
    lateinit var toggle: ActionBarDrawerToggle

    var launcher2 = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {

    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


        binding = ActivityMainscreenBinding.inflate(layoutInflater)
        setContentView(binding.root)


        binding.menuNv.setNavigationItemSelectedListener{
            if (it.itemId == R.id.new_petition) {
                launcher2.launch(Intent(this@Mainscreen, ActivityCreate::class.java))
            }
            if (it.itemId == R.id.logout) {
                startActivity(Intent(this@Mainscreen, MainActivity::class.java))
                finish()
            }
            if (it.itemId == R.id.profile) {
                startActivity(Intent(this@Mainscreen, Activity_profile::class.java))
                finish()
            }

            return@setNavigationItemSelectedListener true
        }

        setSupportActionBar(binding.EsemkaToolbar)
        toggle = ActionBarDrawerToggle(this@Mainscreen,binding.drawerMenu, R.string.open_text, R.string.close_text)

        binding.drawerMenu.addDrawerListener(toggle)
        toggle.syncState()

        supportActionBar?.setDisplayHomeAsUpEnabled(true)


        GlobalScope.launch(Dispatchers.IO){

            try {
                val conn = URL("http://10.0.2.2:5000/petition").openStream().bufferedReader().readText()
                val jsons= JSONArray(conn)

                runOnUiThread {

                    val adapter= object : RecyclerView.Adapter<PetitionViewHolder>() {
                        override fun onCreateViewHolder(
                            parent: ViewGroup,
                            viewType: Int
                        ): PetitionViewHolder {
                            val binding = CardpetitionBinding.inflate(
                                LayoutInflater.from(parent.context),
                                parent,
                                false
                            )
                            return PetitionViewHolder(binding)
                        }

                        override fun getItemCount(): Int {
                            return jsons.length()
                        }

                        override fun onBindViewHolder(holder: PetitionViewHolder, position: Int) {
                            val petitions =jsons.getJSONObject(position)
                            holder.binding.nama.text = petitions.getString("title")
                            holder.binding.petitionDesc.text = petitions.getString("description")
                            holder.binding.petitionMaker.text = petitions.getString("creatorName")

                            Log.d("DEBUG_ADAPTER", jsons.toString());

                            holder.itemView.setOnClickListener {
                                launcher2.launch(Intent(this@Mainscreen, Activity_Detail::class.java).apply {
                                    putExtra("petID", petitions.getString("petitionID"))
                                })
                            }
                        }
                    }
                    binding.recycle.adapter = adapter
                    binding.recycle.layoutManager = LinearLayoutManager(this@Mainscreen)
                }
            }
            catch (e:Exception){
                Log.e("Mainscreen", "Error fetching data: $e")
            }

        }
    }

    class PetitionViewHolder(val binding: CardpetitionBinding) : RecyclerView.ViewHolder(binding.root)

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        toggle.onOptionsItemSelected(item)
        if (item.itemId == R.id.new_petition) {
        }
        return true
    }
}







