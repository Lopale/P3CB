-- Cette ligne permet d'afficher des traces dans la console pendant l'éxécution
io.stdout:setvbuf('no')

largeur_ecran = love.graphics.getWidth()
hauteur_ecran = love.graphics.getHeight()



-- Variables -- 
local level = {};
local nbBrikH = 10;
local nbBrikV = 10;
local brikWidth = 70;
local brikHeight = 23;
local path = "";


function love.keypressed(key)
  if key=="s" then
    
    local datalevel = "";
    
    for l = 1,  nbBrikV do
      for c =1, nbBrikH do
        
        datalevel = datalevel .. level[l][c];
        if c < nbBrikH then
          datalevel = datalevel..',';
          
        end
      end
      if l < nbBrikV then
        datalevel = datalevel .. "\n";
      end
    end
    
    print(datalevel);
    print("Vous avez sauvegardé en appuyant sur "..key);
    
    local fileName = "level"..os.date('%Y%m%d%H%M%S');
    love.filesystem.write(fileName,datalevel);
    
   path ="Sauvegardé dans C:".."/".."Users".."/".."VOTRENOM".."/".."AppData".."/".."Roaming".."/".."LOVE".."/".."_levelMaker".."/"..fileName;
  end
  -- print(key)
  
end

function mousePosition()
  
  local mx,my = love.mouse.getPosition();
  
  colSurvol = math.floor(1+(mx/brikWidth));  
  lignSurvol = math.floor(1+(my/brikHeight));
  
  colSurvolAffiche = colSurvol;  
  lignSurvolAffiche = lignSurvol;

  if colSurvol > nbBrikH or lignSurvol >nbBrikV then
    colSurvolAffiche = "En dehors du tableau";
    lignSurvolAffiche = "En dehors du tableau";
  end
  
  love.graphics.print('souris: '..mx..','..my..'; colonne :'..colSurvolAffiche..'; ligne :'..lignSurvolAffiche, 20,hauteur_ecran-30);
  
  return colSurvol, lignSurvol;
  
end


function love.load()
    love.window.setTitle("Générateur de niveau Cassbrik");
    
    level = {}; --Réinitialisation du niveau
    
    for l = 1,  nbBrikV do
      level[l] = {} 
      for c =1, nbBrikH do
        level[l][c] = 0; -- De base toutes les cellules contiennent 0 donc un niveau vide
      end
    end
  
end

function love.update(dt)
  
  local ligne, colone = mousePosition();
    
  if colSurvol>=1 and colSurvol <= nbBrikH and lignSurvol>=1 and lignSurvol <= nbBrikV then
    if love.mouse.isDown(1) then
      level[colone][ligne] = 1;
    elseif love.mouse.isDown(2) then
      level[colone][ligne] = 0;
    end
  end

end

function love.draw()

  for l = 1,  nbBrikV do
    for c =1, nbBrikH do
      love.graphics.rectangle("line", (c - 1) * brikWidth, (l - 1) * brikHeight, brikWidth, brikHeight); -- Affichage de brique vide
      local id = level[l][c];
      if id > 0 then
        love.graphics.setColor(0.2,0.7,0.9); -- Bleu lopale
        love.graphics.rectangle("fill", (c - 1) * brikWidth, (l - 1) * brikHeight, brikWidth, brikHeight); -- Affichage de brique plein
        love.graphics.setColor(1,1,1);
      end
    
    end
  end
  
  mousePosition();
  
 love.graphics.print( path, 20 ,hauteur_ecran-60);
  
end
