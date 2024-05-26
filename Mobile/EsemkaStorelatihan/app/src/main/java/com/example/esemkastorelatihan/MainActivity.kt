package com.example.esemkastorelatihan

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.fragment.app.Fragment
import com.example.esemkastorelatihan.databinding.ActivityMainBinding
import com.google.android.material.tabs.TabLayout

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private val fragments = listOf(FirstFragment(),SecondFragment())
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    binding = ActivityMainBinding.inflate(layoutInflater)
     setContentView(binding.root)


        val menus = listOf("Menu 1", "Menu 2")

        for (menu in menus) {
            val tab = binding.menuTl.newTab()
            tab.text = menu
            tab.tag = fragments[menus.indexOf(menu)]
            binding.menuTl.addTab(tab)

        }

        showFragment(fragments[0])

        supportFragmentManager.addOnBackStackChangedListener {
            val fragment = supportFragmentManager.findFragmentById(binding.containerFl.id)
            val index = fragments.indexOf(fragment)
            if (index != -1) binding.menuTl.getTabAt(index)?.select()
        }

        binding.menuTl.addOnTabSelectedListener(object : TabLayout.OnTabSelectedListener {
            override fun onTabSelected(tab: TabLayout.Tab?) {
                tab?.let {

                }
            }

            override fun onTabUnselected(tab: TabLayout.Tab?) {}

            override fun onTabReselected(tab: TabLayout.Tab?) {}
        })

    }


    fun showFragment(fragment: Fragment, addToBackStage: Boolean = false) {
        val transaction = supportFragmentManager.beginTransaction()
        transaction.replace(binding.containerFl.id, fragment)
        if (addToBackStage) transaction.addToBackStack(null)
        transaction.commit()
    }
}