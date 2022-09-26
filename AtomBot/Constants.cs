namespace AtomBot;

public class Constants
{
    private static readonly string ConfuseHealthRestore = "Restores 12.5% of its HP when its HP drops to one half or below.";
    private static readonly string NoEffect = "No effect";
    public static readonly Dictionary<string, string> BerryLookup = new()
    {
        {"aguav", ConfuseHealthRestore + " It confuses Pokémon that have -spd natures; Naughty, Rash, Naive, or Lax"},
        {"figy", ConfuseHealthRestore + " It confuses Pokémon that have -att natures; Modest, Timid, Calm, or Bold"},
        {"iapapa", ConfuseHealthRestore + " It confuses Pokémon that have -def natures; Lonely, Mild, Gentle, or Hasty"},
        {"mago", ConfuseHealthRestore + " It confuses Pokémon that have -speed natures; Brave, Quiet, Sassy, or Relaxed"},
        {"wiki", ConfuseHealthRestore + " It confuses Pokémon that have -spa natures; Adamant, Jolly, Careful, or Impish"},
        {"cheri", "Cures paralysis."},
        {"chesto", "Cures sleep."},
        {"pecha", "Cures poison."},
        {"rawst", "Cures burn."},
        {"aspear", "Cures freeze."},
        {"leppa", "Restores 10 PP."},
        {"oran", "Restores 10 HP."},
        {"persim", "Cures confusion."},
        {"lum", "Cures any non-volatile status condition and confusion."},
        {"sitrus", "Restores 30 HP in Gen. III/25% HP in Gen. IV+"},
        {"razz", "Makes wild Pokémon easier to capture"},
        {"bulk", NoEffect},
        {"nanab", "Makes wild Pokémon move less."},
        {"wepear", NoEffect},
        {"pinap", "Makes wild Pokémon more likely to drop items"},
        {"pomeg", "Lowers HP EVs, raises friendship."},
        {"kelpsy", "Lowers Attack EVs, raises friendship"},
        {"qualot", "Lowers Defense EVs, raises friendship"},
        {"hondew", "Lowers Special Attack EVs, raises friendship"},
        {"grepa", "Lowers Special Defense EVs, raises friendship"},
        {"tamato", "Lowers Speed EVs, raises friendship"},
        {"cornn", NoEffect},
        {"magost", NoEffect},
        {"rabuta", NoEffect},
        {"nomel", NoEffect},
        {"spelon", NoEffect},
        {"pamtre", NoEffect},
        {"watmel", NoEffect},
        {"durin", NoEffect},
        {"belue", NoEffect},
        {"occa", "Halves damage taken from a super effective Fire-type move."},
        {"passho", "Halves damage taken from a super effective Water-type move."},
        {"wacan", "Halves damage taken from a super effective Electric-type move."},
        {"rindo", "Halves damage taken from a super effective Grass-type move."},
        {"yache", "Halves damage taken from a super effective Ice-type move."},
        {"chople", "Halves damage taken from a super effective Fighting-type move."},
        {"kebia", "Halves damage taken from a super effective Poison-type move."},
        {"shuca", "Halves damage taken from a super effective Ground-type move."},
        {"coba", "Halves damage taken from a super effective Flying-type move."},
        {"payapa", "Halves damage taken from a super effective Psychic-type move."},
        {"tanga", "Halves damage taken from a super effective Bug-type move."},
        {"charti", "Halves damage taken from a super effective Rock-type move."},
        {"kasib", "Halves damage taken from a super effective Ghost-type move."},
        {"haban", "Halves damage taken from a super effective Dragon-type move."},
        {"colbur", "Halves damage taken from a super effective Dark-type move."},
        {"babiri", "Halves damage taken from a super effective Steel-type move."},
        {"chilan", "Halves damage taken from a super effective Normal-type move."},
        {"leichi", "Raises Attack when HP falls below 25%."},
        {"ganlon", "Raises Defense when HP falls below 25%."},
        {"salac", "Raises Speed when HP falls below 25%."},
        {"petaya", "Raises Special Attack when HP falls below 25%."},
        {"apicot", "Raises Special Defense when HP falls below 25%."},
        {"lansat", "Raises Critical Hit Ratio when HP falls below 25%."},
        {"starf", "Raises a random stat when HP falls below 25%."},
        {"enigma", "—(placeholder for e-Reader Berries) RS. Restores 25% HP when hit with a super effective move in Gen. IV+."},
        {"micle", "Causes next move to bypass accuracy checks in Gen. IV/raises accuracy of next move by ~20% in Gen. V+ when HP falls below 25%."},
        {"custap", "Causes next move to go first in its priority bracket when HP falls below 25%."},
        {"jaboca", "Damages attacker for 12.5% HP when hit with a physical move."},
        {"rowap", "Damages attacker for 12.5% HP when hit with a special move."},
        {"roseli", "Halves damage taken from a super effective Fairy-type move."},
        {"kee", "Raises Defense when hit with a physical move."},
        {"maranga", "Raises Special Defense when hit with a special move."},
        {"hopo", "Restores PP. If used on a wild Pokemon, the wild Pokemon's reactions are dulled."},
        {"egg", "Is it easter?"},
    };
}